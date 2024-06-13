try
{
    Console.Write("Por favor indique a url de entrada (sourceURL): ");
    string sourceURL = Console.ReadLine();

    Console.Write("Por favor indique onde o arquivo de destino será guardado: (targetPath): ");
    string targetPath = Console.ReadLine();

    StreamReader streamReader = new StreamReader(sourceURL);
    string line = streamReader.ReadLine();

    StreamWriter sw = new StreamWriter(targetPath + "Agora.txt");
    sw.WriteLine($"#Version: 1.0\n" +
        $"#Date: {DateTime.Now}\n" +
        $"#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n");

    while (line != null)
    {
        sw.WriteLine("\"MINHA CDN\"\t" + line.Split('|')[3].Split()[0].Replace("\"", "") + "\t" + line.Split('|')[1] + "\t" + line.Split('|')[3].Split()[1] + "\t" + Math.Round(Convert.ToDecimal(line.Split('|')[4])) + "\t" + line.Split('|')[0] + "\t" + line.Split('|')[2]);
        line = streamReader.ReadLine();
    }
    streamReader.Close();
    sw.Close();
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
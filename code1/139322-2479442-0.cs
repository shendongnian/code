    static void Main(string[] arguments)
    {
        const int iterations = 100000;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        string s = CreateUsingStringBuilder("content", iterations);
        sw.Stop();
        Console.WriteLine(String.Format("CreateUsingStringBuilder: {0}", sw.ElapsedMilliseconds));
        sw.Reset();
        sw.Start();
        s = CreateUsingXmlWriter("content", iterations);
        sw.Stop();
        Console.WriteLine(String.Format("CreateUsingXmlWriter: {0}", sw.ElapsedMilliseconds));
        Console.ReadKey();
    }
    private static string CreateUsingStringBuilder(string content, int iterations)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++ )
            sb.AppendFormat("<element>{0}</element>", content);
        return sb.ToString();
    }
    private static string CreateUsingXmlWriter(string content, int iterations)
    {
        StringBuilder sb = new StringBuilder();
        using (StringWriter sw = new StringWriter(sb))
        using (XmlWriter xw = XmlWriter.Create(sw))
        {
            xw.WriteStartElement("root");
            for (int i = 0; i < iterations; i++ )
                xw.WriteElementString("element", content);
            xw.WriteEndElement();
        }
        return sb.ToString();
    }

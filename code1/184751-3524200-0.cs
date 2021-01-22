    using(StreamWriter sw = new StreamWriter(ms)) 
    {
        char[] ca = XmlContent.ToCharArray();      // still working up to this point.
        ms.Position = 0;
        sw.Write(ca);
    }
    StreamReader sr = new StreamReader(ms);
    ms.Position = 0;
    string XmlContentAgain = sr.ReadToEnd();

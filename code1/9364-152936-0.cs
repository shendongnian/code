        XmlDocument doc = new XmlDocument();
        doc.LoadXml(@"<xml>&#8482;</xml>");
        using (MemoryStream ms = new MemoryStream())
        {
            XmlWriterSettings settings = new  XmlWriterSettings();
            settings.Encoding = Encoding.GetEncoding("ISO-8859-1");
            XmlWriter xw = XmlWriter.Create(ms, settings);
            doc.Save(xw);
            xw.Close();
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }

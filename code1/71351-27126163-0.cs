    public static string Beautify(System.Xml.XmlDocument doc)
    {
        string strRetValue = null;
        System.Text.Encoding enc = System.Text.Encoding.UTF8;
        // enc = new System.Text.UTF8Encoding(false);
        
        System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
        xmlWriterSettings.Encoding = enc;
        xmlWriterSettings.Indent = true;
        xmlWriterSettings.IndentChars = "    ";
        xmlWriterSettings.NewLineChars = "\r\n";
        xmlWriterSettings.NewLineHandling = System.Xml.NewLineHandling.Replace;
        //xmlWriterSettings.OmitXmlDeclaration = true;
        xmlWriterSettings.ConformanceLevel = System.Xml.ConformanceLevel.Document;
        
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {
            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(ms, xmlWriterSettings))
            {
                doc.Save(writer);
                writer.Flush();
                ms.Flush();
                writer.Close();
            } // End Using writer
            ms.Position = 0;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(ms, enc))
            {
                // Extract the text from the StreamReader.
                strRetValue = sr.ReadToEnd();
                sr.Close();
            } // End Using sr
            ms.Close();
        } // End Using ms
        /*
        System.Text.StringBuilder sb = new System.Text.StringBuilder(); // Always yields UTF-16, no matter the set encoding
        using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sb, settings))
        {
            doc.Save(writer);
            writer.Close();
        } // End Using writer
        strRetValue = sb.ToString();
        sb.Length = 0;
        sb = null;
        */
        xmlWriterSettings = null;
        return strRetValue;
    } // End Function Beautify

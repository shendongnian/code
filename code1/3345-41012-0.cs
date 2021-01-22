        BufferedStream stream = new BufferedStream(new MemoryStream());
        stream.Write(Encoding.ASCII.GetBytes("<xml>foo</xml>"), 0, "<xml>foo</xml>".Length);
        stream.Seek(0, SeekOrigin.Begin);
        StreamReader sr = new StreamReader(stream);
        XmlReader reader = XmlReader.Create(sr);
        while (reader.Read())
        {
             Console.WriteLine(reader.Value);
        }
        stream.Close();

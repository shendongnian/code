    using(XmlReader r = XmlReader.Create(new StreamReader(fileName, Encoding.GetEncoding("ISO-8859-9")))) {
        while(r.Read()) {
            Console.WriteLine(r.Value);
        }
    }

        var doc = new XDocument(
                new XDeclaration("1.0", "utf-16", "yes"), 
                new XElement("blah", "blih"));
        var wr = new StringWriter();
        doc.Save(wr);
        Console.Write(wr.ToString());

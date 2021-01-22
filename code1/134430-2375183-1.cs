    StringWriter sw = new StringWriter();
    XmlTextWriter xw = new XmlTextWriter(sw);
    xw.Formatting = Formatting.Indented;
    doc.WriteTo(xw);
    Console.WriteLine(sw.ToString());

    using (XmlWriter xw = XmlWriter.Create(sb, new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = true, IndentChars = "\t" }))
    {
        ....
        d.WriteTo(xw);
    }
    System.Diagnostics.Debug.WriteLine(sb.ToString());
    System.Diagnostics.Debug.WriteLine("------------------------------ Done --------------------");

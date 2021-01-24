    using (XmlWriter xw = XmlWriter.Create(sb, new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = true, IndentChars = "\t" }))
    {
        ....
        d.WriteTo(xw);
        xw.Flush();
        System.Diagnostics.Debug.WriteLine(sb.ToString());
    }
    System.Diagnostics.Debug.WriteLine("------------------------------ Done --------------------");

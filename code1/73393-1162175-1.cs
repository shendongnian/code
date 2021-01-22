    for (int i = 0; i < d.SelectNodes("/report/unit").Count; i++)
    {
        XsltArgumentList args = new XsltArgumentList();
        args.AddParam("position", "", i + 1);
        using (StringReader sr = new StringReader(d.OuterXml))
        using (XmlReader xr = XmlReader.Create(sr))
        using (XmlWriter xw = XmlWriter.Create(Console.Out))
        {
            xslt.Transform(xr, args, xw);
        }
    }

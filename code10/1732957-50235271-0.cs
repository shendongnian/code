    var xml = XElement.Load("test.xml");
    var grouped = xml.Elements("Emp")
        .GroupBy(emp => emp.Element("A.EMPLID").Value);
    foreach (var group in grouped)
    {
        var x = new XElement("Connected",
            new XElement("Emp",
                new XElement("A.EMPLID", group.Key),
                group.Select(g => g.Elements().Where(e => e.Name != "A.EMPLID"))));
        x.Save("file" + group.Key + ".xml");
    }

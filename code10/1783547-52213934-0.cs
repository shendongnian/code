        XDocument doc = new XDocument(new XElement("Set"));
        for (int i = 0; i < 10; i++)
        {
            var _Name = "n" + i ;
            var _ID = "12" + i;
            var setting = new XElement("Setting", _Name );
            setting.Add(new XAttribute("empID", _ID));
            doc.Element("Set").Add(setting);
        }
        Console.WriteLine(doc.ToString());

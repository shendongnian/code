    XDocument xdoc = XDocument.Parse(xml);
    xdoc.Root.Elements("item")
        .ToList()
        .ForEach(el=>
        {
            string chk = el.Element("CHK").Value;
            string sel = el.Element("SEL").Value;
            string value = el.Element("VALUE").Value;
    
            // your code here
        });

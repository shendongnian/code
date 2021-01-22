        System.Xml.Linq.XElement element = System.Xml.Linq.XElement.Parse("<Ids>  <id>1</id>  <id>2</id></Ids>");
        System.Collections.Generic.List<string> ids = new System.Collections.Generic.List<string>();
        foreach (System.Xml.Linq.XElement childElement in element.Descendants("id"))
        {
            ids.Add(childElement.Value);
        }

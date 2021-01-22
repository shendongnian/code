    using System.Linq;
    using System.Xml.Linq;
    void Delete()
    {
        XDocument document = LoadXML();
        document.Elements("Users")
            .Single(e => e.Attribute("ID").Value == "3")
            .Remove();
    }

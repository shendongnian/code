    private void BindCountry()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("countries.xml"));
        foreach (XmlNode node in doc.SelectNodes("//country"))
        {
            XmlAttribute attr = node.Attributes["codes"];
            if (attr != null)
            {
                usrlocationddl.Items.Add(new ListItem(node.InnerText, attr.Value));
            }
        }
    }

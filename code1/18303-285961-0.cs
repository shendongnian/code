    System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
    xml.LoadXml(xmlSample);
    
    System.Xml.XmlElement _root = xml.DocumentElement;
    
    foreach (System.Xml.XmlNode _node in _root)
    {
        Literal1.Text = "<hr/>" + _node.Name + "<br/>";
        for (int iAtt = 0; iAtt < _node.Attributes.Count; iAtt++)
            Literal1.Text += _node.Attributes[iAtt].Name + " = " + _node.Attributes[iAtt].Value + "<br/>";
    }

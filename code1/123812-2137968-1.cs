    //Here is the variable with which you assign a new value to the attribute
        string newValue = string.Empty 
        XmlDocument xmlDoc = new XmlDocument();
    
        xmlDoc.Load(xmlFile);
    
        XmlNode node = xmlDoc.SelectSingleNode("Root/Node/Element");
        node.Attributes[0].Value = newValue;
    
        xmlDoc.Save(xmlFile);

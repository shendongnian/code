    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.AppendChild(xmlDoc.CreateElement("form"));
    XmlElement nameElement = xmlDoc.CreateElement("name");
    nameElement.InnerText = nameCtrl.Text;
    xmlDoc.DocumentElement.AppendChild(nameElement);
    XmlElement emailElement = xmlDoc.CreateElement("email");
    emailElement.InnerText = emailCtrl.Text;
    xmlDoc.DocumentElement.AppendChild(emailElement);

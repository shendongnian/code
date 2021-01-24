    XmlDocument Doc = new XmlDocument();
        XmlDeclaration dec = Doc.CreateXmlDeclaration("1.0", null, null);
        Doc.AppendChild(dec);
        XmlElement DocRoot = Doc.CreateElement("settings");
        Doc.AppendChild(DocRoot);
        
        XmlNode server = Doc.CreateElement("textbox1");
        DocRoot.AppendChild(server);
        server.InnerText = this.TextBox1.Text;
        
        XmlNode server2 = Doc.CreateElement("textbox2");
        DocRoot.AppendChild(server2);
        server2.InnerText = this.TextBox2.Text;
        
        Doc.Save(Application.StartupPath + "\\xmlfile.xml");

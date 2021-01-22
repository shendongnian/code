    public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string targetDirectory = Context.Parameters["targetdir"];
            string param1 = Context.Parameters["param1"];
            string path = System.IO.Path.Combine(targetDirectory, "app.config");
			System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(path);
            System.Xml.XmlNode node = xDoc.SelectSingleNode("/configuration/applicationSettings/Intellisense.ApplicationServer.Properties.Settings/setting[@name='ApplicationServer_ApplicationServerUrl']/value");
            node.InnerText = (param1.EndsWith("/") ? param1 : param1 + "/");
            xDoc.Save(path); // saves the web.config file  
        }

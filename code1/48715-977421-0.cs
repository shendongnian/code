        public static string GetSystemVersion(HttpServerUtility server)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(server.MapPath("~/web.config"));
            System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("bla", "http://schemas.microsoft.com/.NetConfiguration/v2.0");
            System.Xml.XmlNode node = doc.SelectSingleNode("/bla:configuration/bla:system.web/bla:authentication/bla:forms[@name]", ns);
            string projectName = "";
            if (node != null && node.Attributes != null && node.Attributes.GetNamedItem("name") != null)
                projectName = node.Attributes.GetNamedItem("name").Value; //in my case, that value is identical to the project name (projetname.dll)
            else
                return "";
            Assembly assembly = Assembly.Load(projectName);
            return assembly.GetName().Version.ToString();
        }

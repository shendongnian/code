        public void CompareXMLInDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            CompareXML(dir.GetFiles("*.xml"));
        }
        public void CompareXML(FileInfo[] xmlFileNames)
        {
            XmlDocument[] xmlDocuments = new XmlDocument[xmlFileNames.Length];
            for(int i = 0; i < xmlFileNames.Length; i++)
            {
                xmlDocuments[i] = new XmlDocument();
                xmlDocuments[i].Load(xmlFileNames[i].FullName);
            }
            //...do compare work here
        }

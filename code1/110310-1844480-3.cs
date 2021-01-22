    public void CompareMyXMLFiles()
    {
        string[] files = { "ilk.xml", "migr.xml", "caa.xml" };
        CompareXML(@"c:\markets", files);
    }
    
    public void CompareXML(string basePath, string[] xmlFileNames)
    {
        XmlDocument[] xmlDocuments = new XmlDocument[xmlFileNames.Length];
        for(int i = 0; i < xmlFileNames.Length; i++)
        {
            xmlDocuments[i] = new XmlDocument();
            xmlDocuments[i].Load(basePath + @"\" + xmlFileNames[i]);
        }
    
        //...do compare work here
    }

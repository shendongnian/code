       public void ReadResultsXmlFile(string testResultsXmlFile)
    {
        MyXmlTextReader = new XmlTextReader(testResultsXmlFile);
        testResultXmlDocument = new XmlDocument();
        testResultXmlDocument.Load(MyXmlTextReader); 
        XmlNode xnAssembliesHeader = testResultXmlDocument.SelectSingleNode("/assemblies");
        XmlNodeList xnAssemblyList = testResultXmlDocument.SelectNodes("/assemblies/assembly");
        foreach (XmlNode assembly in xnAssemblyList)
        {
            XmlNodeList xnTestList = testResultXmlDocument.SelectNodes(
                "/assemblies/assembly/collection/test");
            foreach (XmlNode test in xnTestList)
            {
                TestName = test.Attributes.GetNamedItem("name").Value;
                TestDuration = test.Attributes.GetNamedItem("time").Value;
                PassOrFail = test.Attributes.GetNamedItem("result").Value;
            }
        }
    }

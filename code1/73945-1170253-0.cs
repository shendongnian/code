        XmlDocument doc = new XmlDocument();
        doc.LoadXml(@"<test xmlns='myFunkyUri' value='abc'/>");
        // wrong; no namespace consideration
        XmlElement root = (XmlElement)doc.SelectSingleNode("test");
        Console.WriteLine(root == null ? "(no root)" : root.GetAttribute("value"));
        // right
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("x", "myFunkyUri"); // x is my alias for myFunkyUri
        root = (XmlElement)doc.SelectSingleNode("x:test", nsmgr);
        Console.WriteLine(root == null ? "(no root)" : root.GetAttribute("value"));

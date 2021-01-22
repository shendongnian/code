     XmlDocument doc1 = new XmlDocument();
        XmlDocument doc2 = new XmlDocument();
        doc1.Load(@"c:\myproject\WindowsApplication1\sitemap.xml");
        doc2.Load(@"c:\myproject\WindowsApplication1\mouse.xml");
    
        XmlNodeList a = doc1.GetElementsByTagName("Name");
        XmlNodeList b = doc2.GetElementsByTagName("Name");
        if (a.Count == 1 && b.Count == 1)
        {
            if (a[0].InnerText == b[0].InnerText)
                Console.WriteLine("Equal");
            else
                Console.WriteLine("Not Equal");
        }

    doc.Load(temp);
    XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
    nsMgr.AddNamespace("pkg", "http://www.sample-package.org");
    var root = doc.GetElementsByTagName("Head");
    var documents = new List<Dictionary<string, object>>();
    for (int i = 0; i < root.Count; i++)
    {
        var head = root[i];
        var document = new Dictionary<string, object>();
        document.Add("N", head.SelectSingleNode("/pkg:Head/pkg:Number", nsMgr).InnerText);
        document.Add("NC", head.SelectSingleNode("/pkg:Head/pkg:Number_confirm", nsMgr).InnerText);
        document.Add("ID", head.SelectSingleNode("/pkg:Head/pkg:Positions/pkg:Product_id", nsMgr).InnerText);
        documents.Add(document);
    }

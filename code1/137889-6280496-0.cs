        string content="";
        foreach (SyndicationElementExtension ext in item.ElementExtensions)
        {
            if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                content = ext.GetObject<XElement>().Value;
        }

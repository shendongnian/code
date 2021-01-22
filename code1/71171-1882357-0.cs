    StringBuilder sb = new StringBuilder();
    foreach (SyndicationElementExtension extension in item.ElementExtensions)
        {
             XElement ele = extension.GetObject<XElement>();
             if (ele.Name.LocalName == "encoded" && ele.Name.Namespace.ToString().Contains("content"))
             {
                  sb.Append(ele.Value + "<br/>");
             }
        }

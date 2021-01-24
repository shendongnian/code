    private void removeAnnotations(XmlDocument doc)
    {
        XmlNamespaceManager manager = new XmlNamespaceManager(new NameTable());
        manager.AddNamespace("NS1","http://www.someurl.net");
        XmlNodeList annotations = doc.SelectNodes("//NS1:annotation", manager);
        
        int i = 0;
        while (i < annotations.Count) 
        {
          //in mixed xml the Siblings are xml text nodes. Therefore we write them into buffers:        
          string s0 = "";
          if(annotations[i].PreviousSibling != null) s0 = annotations[i].PreviousSibling.InnerText;        
          string s2 = "";
          if(annotations[i].NextSibling != null) s2 = annotations[i].NextSibling.InnerText;
          //buffer the content of the annotation itself
          string s1 = annotations[i].InnerText;       
          //buffer the link to the parent node before we remove the annotation,
          XmlNode parent = annotations[i].ParentNode;
          //now remove the annotation
          parent.RemoveChild(annotations[i]);
          //and apply the new Text to the parent element
          parent.InnerText = s0 + s1 + s2;
          i++;
        }
    }

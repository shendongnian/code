    while (r.ReadToFollowing("ParentNode"))
    {
        parentXml = r.ReadOuterXml();
        //since ReadOuterXml() advances the reader to the next parent node, create a new reader to read the remaining elements of the current parent
        XmlReader r2 = XmlReader.Create(new StringReader(parentXml));
        r2.ReadToFollowing("ChildNode");
        childValue = r2.ReadElementContentAsString();
        r2.Close();
    }                  

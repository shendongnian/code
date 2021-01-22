    public void DoParse(string value, string elementname)
    {
	    var split = value.Split((char)39);
   
	    XmlDocument xDoc = new XmlDocument();
    	XmlElement xRoot = xDoc.CreateElement(elementname);
	    xDoc.AppendChild(xRoot);
    
	    for (var i = 0; i < split.Length - 1; i += 2)
    	{
    		var attribName = split[i].Replace("=", "").Trim();
    		var xAttrib = xDoc.CreateAttribute(attribName);
    		xAttrib.Value = split[i + 1];
    		xRoot.Attributes.Append(xAttrib);
	    }
    	xDoc.Save(string.Format("c:\\xmlout_{0}.xml", elementname));
    }

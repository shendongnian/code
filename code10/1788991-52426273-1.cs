    var MiXMLD = new XmlDocument();
    
    MiXMLD.Load(@"C:\path\MiXML.xml");
    
    if (!(MiXMLD == null))
    {
    	XmlElement mXMLERaiz = MiXMLD.DocumentElement;
    
    	foreach (XmlNode mXMLN in mXMLERaiz.ChildNodes)
    	{
    		// if type is <SITE>
    		if ((mXMLN.Name == "SITE"))
    		{
    			//In this point you can see the attributes
    			if ((mXMLN.Attributes.Count > 0))
    			{
    				foreach (XmlAttribute mAtr in mXMLN.Attributes)
    				{
    					if ((mAtr.Name == "Exalmple"))
    					{
    						var attr = mAtr.Value;
    					}
    					else if ((mAtr.Name == "Example"))
    					{
    						var attr = mAtr.Value;
    					}
    
    				}
    
    			}
    
    			// first node child of element of <parent>
    			// you already know the type <Type>
    			XmlElement mXMLchild = (XmlElement)mXMLN.FirstChild;
    
    			// aniway check the Type
    			if ((mXMLchild.Name == "Type"))
    			{
    				var mChild = mXMLchild.FirstChild.Value;
    			}
    
    		}
    	}
    }  
              

    //itemValues is collection of items in Key value pair format
    //fileName i name of XML file which to creatd or modified with content
        private void WriteInXMLFile(System.Collections.Generic.Dictionary<string, object> itemValues, string fileName)
        {
        	string filePath = "C:\\\\tempXML\\" + fileName + ".xml";
        	try
        	{
        	  
        		if (System.IO.File.Exists(filePath))
        		{
        			XmlDocument doc = new XmlDocument();
        			doc.Load(filePath);                   
        
        			XmlNode rootNode = doc.SelectSingleNode("Documents");
        
        			XmlNode pageNode = doc.CreateElement("Document");
        			rootNode.AppendChild(pageNode);
        		  
        
        			foreach (string key in itemValues.Keys)
        			{
        				
        				XmlNode attrNode = doc.CreateElement(key);
        				attrNode.InnerText = Convert.ToString(itemValues[key]);
        				pageNode.AppendChild(attrNode);
        				//doc.DocumentElement.AppendChild(attrNode);
        				
        			}
        			doc.DocumentElement.AppendChild(pageNode);
        			doc.Save(filePath);
        		}
        		else
        		{
        			XmlDocument doc = new XmlDocument();
        			using(System.IO.FileStream fs = System.IO.File.Create(filePath))
        			{
        				//Do nothing
        			}
        
        			XmlNode rootNode = doc.CreateElement("Documents");
        			doc.AppendChild(rootNode);
        			doc.Save(filePath);
        
        			doc.Load(filePath);
        
        			XmlNode pageNode = doc.CreateElement("Document");
        			rootNode.AppendChild(pageNode);
        		 
        			foreach (string key in itemValues.Keys)
        			{                          
        				XmlNode attrNode = doc.CreateElement(key);                           
        				attrNode.InnerText = Convert.ToString(itemValues[key]);
        				pageNode.AppendChild(attrNode);
        				//doc.DocumentElement.AppendChild(attrNode);
        
        			}
        			doc.DocumentElement.AppendChild(pageNode);
        
        			doc.Save(filePath);
        		   
        		}
        	}
        	catch (Exception ex)
        	{
        		
        	}
        			  
        }
        
    OutPut look like below
    <Dcouments>
    	<Document>
    		<DocID>01<DocID>
    		<PageName>121<PageName>
    		<Author>Mr. ABC<Author>
    	<Dcoument>
    	<Document>
    		<DocID>02<DocID>
    		<PageName>122<PageName>
    		<Author>Mr. PQR<Author>
    	<Dcoument>
    </Dcouments>

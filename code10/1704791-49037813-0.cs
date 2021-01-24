    var xmlDoc = new XmlDocument();
                var finalXmlDoc = new XMLDocument();
    			finalXmlDoc.LoadXml( "<xml/>" );
    
    
                while (true)
                {
                     //BUILD URL FOR EACH ITERATION AND DO AN HTTP GET                                       
    
                     xmlDoc.Load(prospectResp);
    
                     var nodes = xmlDoc.DocumentElement.SelectNodes("/rsp/result/prospect");
    
                     foreach (XmlNode node in nodes)
                     {
                         impNode = finalXmlDoc.ImportNode(node, true);
    
                         finalXmlDoc.DocumentElement.AppendChild(impNode);
                     }                
                     // EVENTUALLY BREAK LOOP AND EXPORT finalXmlDoc
                }
"

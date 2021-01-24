     foreach (XmlNode node in xmlDoc.SelectNodes("//DAV:schemata/DAV:classschema[DAV:base_class='File']", nsmgr))
               
                {
                    //strNode = node.Attributes["name"].Value;
                    //if (node.InnerText == "File")
                   // {
                        strNode = node.Attributes["name"].Value;
                        //strNode = node.InnerText;
                        responseString += strNode +" ";
                   // }                   
                }
                return responseString;

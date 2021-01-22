    XmlDocument objXmlDocument1 = null;
    objXmlDocument1 = new XmlDocument();
    objXmlDocument1.Load(System.Web.HttpContext.Current.Server.MapPath("") + "\\XMLSchema\\" + "ABC.xml");
    XMLNodesList nodes1 = objXmlDocument1.GetElementsByTagName("Designation");
    foreach (XmlNode n in nodes1)
                            {
                                if (n.Attributes["Role"].Value.Trim().Equals("XXX")
                                {                                
                                    objnode1 = n;
                                    break;
    
                                }
    
                            }
    if (objnode1 != null)
                            {
                                XmlNodeList innerNodes1 = objnode1.ChildNodes;
                                XmlNode newNode1 = objXmlDocument1.CreateElement("Designation");
                                XmlAttribute newAtt1 = objXmlDocument1.CreateAttribute("Role");
                                newAtt1.Value = "Ka";
                                newNode1.Attributes.Append(newAtt1);
                                newNode1.InnerXml=objnode1.InnerXml;
                                objXmlDocument1.DocumentElement.AppendChild(newNode1);
                              }
    objXmlDocument1.Save(System.Web.HttpContext.Current.Server.MapPath("") + "\\XMLSchema\\" + "ABC.xml");

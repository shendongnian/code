                //input is a String with some valid XML
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(input);
                XmlNodeList nodeList = doc.SelectNodes("//*");
    
                foreach (XmlNode node in nodeList)
                {
                    if (node.Name.ToUpper().Contains("PASSWORD"))
                    {
                        node.InnerText = "XXXX";
                    }
                    else if (node.Attributes.Count > 0)
                    {
                        foreach (XmlAttribute a in node.Attributes)
                        {
                            if (a.LocalName.ToUpper().Contains("PASSWORD"))
                            {
                                a.InnerText = "XXXXX";
                            }
                        }
                    }    
                }

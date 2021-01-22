    public void UpdateNodes(XmlDocument doc, string newVal)
            {
                XmlNodeList folderNodes = doc.SelectNodes("folder");
    
                if (folderNodes.Count > 0)
                foreach (XmlNode folderNode in folderNodes)
                {
                    XmlNode updateNode = folderNode.SelectSingleNode("nodeToBeUpdated");
                    XmlNode mustExistNode = folderNode.SelectSingleNode("nodeMustExist"); ;
                    if (updateNode != null)
                    { 
                        updateNode.InnerText = newVal;
                    }
                    else if (mustExistNode != null)
                    {
                        XmlNode node = folderNode.OwnerDocument.CreateNode(XmlNodeType.Element, "nodeToBeUpdated", null);
                        node.InnerText = newVal;
                        folderNode.AppendChild(node);
                    }
    
                }
            }

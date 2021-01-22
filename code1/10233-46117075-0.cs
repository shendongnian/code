    private static bool compareXML(XmlNode node, XmlNode comparenode)
        {
            
            if (node.Value != comparenode.Value)
                return false;
            
                if (node.Attributes.Count>0)
                {
                    foreach (XmlAttribute parentnodeattribute in node.Attributes)
                    {
                        string parentattributename = parentnodeattribute.Name;
                        string parentattributevalue = parentnodeattribute.Value;
                        if (parentattributevalue != comparenode.Attributes[parentattributename].Value)
                        {
                            return false;
                        }
                        
                    }
                }
              if(node.HasChildNodes)
                {
                sortXML(comparenode);
                if (node.ChildNodes.Count != comparenode.ChildNodes.Count)
                    return false;
                for(int i=0; i<node.ChildNodes.Count;i++)
                    {
                    
                    string name = node.ChildNodes[i].LocalName;
                    if (compareXML(node.ChildNodes[i], comparenode.ChildNodes[i]) == false)
                        return false;
                    }
                }
                    
            
            return true;
        }

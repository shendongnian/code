     private static void sortXML(XmlNode documentElement)
        {
            int i = 1;
            SortAttributes(documentElement.Attributes);
            SortElements(documentElement);
            foreach (XmlNode childNode in documentElement.ChildNodes)
            {
                sortXML(childNode);
                
            }
        }
 
      private static void SortElements(XmlNode rootNode)
        {
           
           
            
                for(int j = 0; j < rootNode.ChildNodes.Count; j++) {
                    for (int i = 1; i < rootNode.ChildNodes.Count; i++)
                    {
                        if (String.Compare(rootNode.ChildNodes[i].Name, rootNode.ChildNodes[1 - 1].Name) < 0)
                        {
                            rootNode.InsertBefore(rootNode.ChildNodes[i], rootNode.ChildNodes[i - 1]);
                           
                        }
                    }
                }
               // Console.WriteLine(j++);
            
        }
     private static void SortAttributes(XmlAttributeCollection attribCol)
        {
            if (attribCol == null)
                return;
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 1; i < attribCol.Count; i++)
            {
                    if (String.Compare(attribCol[i].Name, attribCol[i - 1].Name) < 0)
                    {
                        //Replace
                        attribCol.InsertBefore(attribCol[i], attribCol[i - 1]);
                        changed = true;
                    }
                }
            }
        }
  

          private static void  SortElementAttributesBasis(XmlNode rootNode)
        {
            
            for (int j = 0; j < rootNode.ChildNodes.Count; j++)
            {
                for (int i = 1; i < rootNode.ChildNodes.Count; i++)
                {
                    Console.WriteLine(rootNode.OuterXml);
                    DateTime dt1 = DateTime.ParseExact(rootNode.ChildNodes[i].Attributes["sTime"].Value, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime dt2 = DateTime.ParseExact(rootNode.ChildNodes[i-1].Attributes["sTime"].Value, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    int compare = DateTime.Compare(dt1,dt2);
                    if (compare < 0)
                    {
                        rootNode.InsertBefore(rootNode.ChildNodes[i], rootNode.ChildNodes[i - 1]);
                        Console.WriteLine(rootNode.OuterXml);
                    }
                    // Provide the name of Attribute in .Attribute["Name"] based on value you want to sort.
                     
                       //if (String.Compare(rootNode.ChildNodes[i].Attributes["sTime"].Value, rootNode.ChildNodes[1 - 1].Attributes["sTime"].Value) < 0)
                    //{
                    //    rootNode.InsertBefore(rootNode.ChildNodes[i], rootNode.ChildNodes[i - 1]);
                    //}
                }
            }
        }
        

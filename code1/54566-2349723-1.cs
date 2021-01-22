    string documentPath = @"C:\Docs\cim_schema_2.18.1-Final-XMLAll\all_classes.xml";
    
    Dictionary<string, List<int>> nodeTable = new Dictionary<string, List<int>>();
    using (XmlReader reader = XmlReader.Create(documentPath))
    {
        while (!reader.EOF)
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                if (!nodeTable.ContainsKey(reader.LocalName))
                {
                    nodeTable.Add(reader.LocalName, new List<int>(new int[] { reader.Depth }));
                }
                else if (!nodeTable[reader.LocalName].Contains(reader.Depth))
                {
                    nodeTable[reader.LocalName].Add(reader.Depth);
                }
            }
            reader.Read();
        }
    }
    Console.WriteLine("The node table has {0} items.",nodeTable.Count);
    foreach (KeyValuePair<string, List<int>> kv in nodeTable)
    {
        Console.WriteLine("{0} [{1}]",kv.Key, kv.Value.Count);
        for (int i = 0; i < kv.Value.Count; i++)
        {
            if (i < kv.Value.Count-1)
            {
                Console.Write("{0}, ", kv.Value[i]);
            }
            else
            {
                Console.WriteLine(kv.Value[i]);
            }
        }
    }

    // Here your xml file
    string xmlFile = "Data.xml";
    
    DataSet dataSet = new DataSet();
    dataSet.ReadXml(xmlFile, XmlReadMode.InferSchema);
    
    // Then display informations to test
    foreach (DataTable table in dataSet.Tables)
    {
        Console.WriteLine(table);
        for (int i = 0; i < table.Columns.Count; ++i)
            Console.Write("\t" + table.Columns[i].ColumnName.Substring(0, Math.Min(6, table.Columns[i].ColumnName.Length)));
        Console.WriteLine();
        foreach (var row in table.AsEnumerable())
        {
            for (int i = 0; i < table.Columns.Count; ++i)
            {
                Console.Write("\t" + row[i]);
            }
            Console.WriteLine();
        }
    }

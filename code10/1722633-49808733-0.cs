    string RESULT_OF_SectionDatatable = "<note><to>Tove</to><from>Jani</from><heading>Reminder</heading><body>Don't forget me this weekend!</body></note>";
    var xmlReader = XmlReader.Create(new StringReader(RESULT_OF_SectionDatatable));
    
    DataSet ds = new DataSet();
    ds.ReadXml(xmlReader);
    
    foreach (DataTable table in ds.Tables)
    {
        Console.WriteLine(table);
        Console.WriteLine();
    
        foreach (var row in table.AsEnumerable())
        {
            for (int i = 0; i < table.Columns.Count; ++i)
            {
    			Console.WriteLine(table.Columns[i].ColumnName +"\t" + row[i]);
            }
            Console.WriteLine();
        }
    }

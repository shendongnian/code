    int count = reader.FieldCount;
    List<List<string>> data = new List<List<string>>();
    while(reader.Read()) {
        data.Add(Enumerable.Range(0,count -1).Select(it => reader.GetValue(it)));    
    }

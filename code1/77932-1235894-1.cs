    List<SomeCustomObject> data = new List<SomeCustomObject>();
    while(reader.Read()) {
       int id = reader.GetInt32(0);
       string name = reader.GetString(1);
       data.Add(new SomeCustomObject(id, name);
    }

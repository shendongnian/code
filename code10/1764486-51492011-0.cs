    var filePath = @"path.json";
    // Read existing json data
    var jsonData = System.IO.File.ReadAllText(filePath);
    // De-serialize to object or create new list
    var SomeObjectList= JsonConvert.DeserializeObject<List<T>>(jsonData) 
                          ?? new List<T>();
    
    // Add any new 
    SomeObjectList.Add(new T()
    {
        Name = "..."
    });
    SomeObjectList.Add(new T()
    {
        Name = "..."
    });
    // edit 
    var first = SomeObjectList.FirstOrDefault();
    first.Name = "...";
    // Update json data string
    jsonData = JsonConvert.SerializeObject(SomeObjectList);
    System.IO.File.WriteAllText(filePath, jsonData);

    List<string> items = new List<string>()
    {
        "test1",
        "test2",
        "test3"
    };
    
    string itemsString = JsonConvert.SerializeObject(items);
    Response.Write(itemsString);

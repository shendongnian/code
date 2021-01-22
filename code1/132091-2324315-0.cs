    List<string> items = new List<string>()
    {
        "test1",
        "test2",
        "test3"
    };
    var json = JsonConvert.SerializeObject(items);
    Response.Write(json);

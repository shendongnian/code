	var data = new Dictionary<string, object>
	{
		{
            "719A070E-4874-E811-9CCE-02152146006A",  
            new { userId = "719A070E-4874-E811-9CCE-02152146006A", Name = "Joe" }
        }
	};
    var json = JsonConvert.SerializeObject(data);
    Console.WriteLine(json);

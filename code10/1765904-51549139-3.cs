    [HttpPost]
    public IActionResult Post([FromForm] Dictionary<string,string> items)
    {
        // convert manually to JSON
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(items);
        Console.WriteLine(json);
        // use the framework to return JSON.
        return new JsonResult(items);
    }

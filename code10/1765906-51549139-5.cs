    [HttpPost]
    public IActionResult Post([FromForm] Dictionary<string,string> items)
    {
        // convert to JSON
        var json = Newtonsoft.Json.JsonConvert
            .SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
        Console.WriteLine(json);
        // return JSON.
        return new JsonResult(items);
    }

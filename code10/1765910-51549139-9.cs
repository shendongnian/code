    [HttpPost]
    public IActionResult Post([FromForm] Dictionary<string,string> model)
    {
        // convert to JSON
        var json = Newtonsoft.Json.JsonConvert
            .SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
        Console.WriteLine(json);
        // return JSON
        return new JsonResult(model);
    }

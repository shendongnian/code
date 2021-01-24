    [HttpPost]
    public IActionResult Post([FromForm] Dictionary<string,string> value)
    {
        Console.WriteLine("==================");
        Console.WriteLine("==================");
        foreach(var val in value) {
            Console.WriteLine(val.Key);
        }
        Console.WriteLine("==================");
        Console.WriteLine("==================");
        return Ok();
    }

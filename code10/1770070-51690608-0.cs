    public IActionResult Entry()
    {
        var tempDataStr = TempData["books"] as string;
        // De serialize the string to object
        var books = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(tempDataStr);
        // Use books
        // to do : return something
    }

    [HttpPost]
    public IActionResult Create([FromBody] Dictionary<string, object> jsonMenu)
    {
        //Code
        return RedirectToAction("Index", "Home");
    }

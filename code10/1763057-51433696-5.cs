    public IActionResult Index()
    {
        var monthlists = new List<string>() { "January", "February", "March" };
        // ViewBag.Exponate = string.Join(",", monthlists);
        ViewBag.Exponate = 
            Newtonsoft.Json.JsonConvert.SerializeObject(monthlists);
        return View();
    }

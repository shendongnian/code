    public IActionResult Index() {
        var monthList = new List<string>() {"January", "February", "March"};
        // ViewBag.Exponate = string.Join(",", monthList);
        ViewBag.Exponate = 
            Newtonsoft.Json.JsonConvert.SerializeObject(monthList);
        return View();
    }

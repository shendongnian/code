    public IActionResult GetHTML()
    {
        var model = new ModelClass() { Content = "Hi!" };
    
        // or
        // return PartialView("GetHTML", model);
        return PartialView(nameof(GetHTML), model);
    }

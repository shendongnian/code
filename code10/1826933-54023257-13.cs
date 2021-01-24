    [HttpGet]
    public IActionResult Create()
    {
        var model = new Trackable<Customer>(new Customer()) { Added = true };
        return PartialView("RowTemplate", model);
    }

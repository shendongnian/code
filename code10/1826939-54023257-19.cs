    [HttpGet]
    public IActionResult Index()
    {
        if (list == null)
        {
            list = Enumerable.Range(1, 5).Select(x => new Customer()
            {
                Id = x,
                FirstName = $"A{x}",
                LastName = $"B{x}",
                Email = $"A{x}@B{x}.com"
            }).ToList();
        }
        var model = list.Select(x => new Trackable<Customer>(x)).ToList();
        return View(model);
    }

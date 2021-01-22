    public ActionResult Index()
    {
        var customers = new[]
        {
            new Customer { Id = 1, Name = "customer 1" },
            new Customer { Id = 2, Name = "customer 2" },
        };
        return this.Csv(customers);
    }

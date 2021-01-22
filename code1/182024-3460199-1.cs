    public ActionResult Index()
    {
        var model = Enumerable
            .Range(1, 11)
            .Select(i => new Pirate { 
                Id = i, 
                PirateReason = string.Format("reason {0}", i) 
            });
        return View(model);
    }

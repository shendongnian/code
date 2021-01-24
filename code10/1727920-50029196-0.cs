    public ActionResult AddThing()
    {
        this._thingService.Things.Add(new Thing());
        return View();
    }

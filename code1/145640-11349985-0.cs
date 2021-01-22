    public ActionResult Index()
    {
        return Json(new DataContext().Ingredients.Select(i => new {
            Name = i.Name,
            UnitName = i.UnitName,
            UnitAmount = i.UnitAmount
        }));
    }

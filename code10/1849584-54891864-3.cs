    [ResponseType(typeof(List<Prestation>))]
    public ActionResult GetPrestations()
    {
        var presentations = db.Prestations.ToList();
        return Content(JsonConvert.Seriazlize(presentations), "application/json");
    }

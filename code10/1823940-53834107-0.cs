    public ActionResult Rent(string id)
    {
        Rent rentItem = new Rent();
        return RedirectToAction("Create", "Rents", new { carId = id, rent = rentItem});
    }

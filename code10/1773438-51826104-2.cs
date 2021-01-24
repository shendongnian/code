    public JsonResult Lowx()
    {
        var query = db.Infoes.
            Select(x => new()
            {
                FirstName = x.Profile.FirstName,
                LastName = x.Profile.LastName,
                MiddleName = x.Profile.MiddleName,
                BirthDate = x.Profile.BirthDate,
                CarName = x.Car.CarName,
                CarNumber = x.Car.CarNumber
            });
        return Json(new { data = query });
    }

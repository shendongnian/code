    // !! This is a POST transaction from ajax
    [HttpPost]
    // !! This should return something to ajax call
    public JsonResult UpdateCity(City model, long CurrentUserId)
    {
        try
        {
            var city = db.Cities.Where(x => x.CityId == model.CityId && x.IsActive == true).FirstOrDefault();
            if (city == null) return false;
            city.CityName = model.CityName;
            city.UpdateBy = CurrentUserId;
            city.UpdateOn = DateTime.UtcNow;
            db.SaveChanges();
            // !! Change return type to Json
            return Json(true);
        }
        catch (Exception Ex)
        {
            // !! Change return type to Json
            return Json(false);
        }
    }

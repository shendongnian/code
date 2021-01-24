    public ActionResult ViewCitybyState(string id)
    {
        int ddValue;
   
        bool isNumber = int.TryParse(id, out ddValue);
        if(isNumber)
        {
            // _context is an assumption of what your connection string is
            // Cities is an assumption of the table you're using to hold the city names
            var cities = _context.Cities.Where(x => x.StateId == ddValue).Select(x => new { Text = x.CityName, Value = x.Id }).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }

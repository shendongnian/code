    public ActionResult ClosestDriverList(double Latitude, double Longitude)
    {
        using (DataContext DbContextHelper = new DataContext())
        {
            var coord = new GeoCoordinate(Latitude, Longitude);
            var nearest = DbContextHelper.DriverLocationModels.Select(x => new
            {
                geocoord = new GeoCoordinate
                {
                    Latitude = (double?)x.DriverLatitude ?? 0,
                    Longitude = (double?)x.DriverLongitude ?? 0
                },
                x.DriverId  // <----- this is what you're missing
            }).AsEnumerable().OrderBy(x => x.geocoord.GetDistanceTo(coord));
        }
    
        return View();
    }

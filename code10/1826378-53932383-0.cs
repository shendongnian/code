    public ActionResult ClosestDriverList(double Latitude, double Longitude)
    {
        using (DataContext DbContextHelper = new DataContext())
        {
            var coord = new GeoCoordinate(Latitude, Longitude);
            var nearest = DbContextHelper.DriverLocationModels.OrderBy(d =>
                coord.DistanceTo(
                    new GeoCoordinate
                    {
                        Latitude = (double?)d.DriverLatitude ?? 0,
                        Longitude = (double?)x.DriverLongitude ?? 0
                    }
                )
            ).FirstOrDefault()?.DriverId ?? 0;
         }
          return View();
    }

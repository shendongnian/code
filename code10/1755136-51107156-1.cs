    public void AddDriver(Driver newDriver)
    {
        using (var db = new VehicleReservationEntities())
        {
            db.Driver.Add(newDriver);
            db.SaveChanges();
        }
    }

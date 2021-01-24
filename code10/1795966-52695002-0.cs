    using (var db = new ApplicationDbContext())
    {
        try
        {
            const string query = "GetPendingReservations";
    
            // First(), FirstOrDefault() or SingleOrDefault() may also be used
            return db.Database.SqlQuery<int>(query).Single();
        }
        catch (Exception ex)
        {
            // exception handling
        }
    }

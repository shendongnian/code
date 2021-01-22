    public class MyRepository
    {
        IQueryable<Location> FindAll()
        {
            List<Location> myLocations = ....;
            return myLocations.AsQueryable<Location>;
            // here Query can only be applied on this
            // subset, not directly to the database
        }
    }

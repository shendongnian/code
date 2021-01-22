    public List<Organization> GetByLocation(Location l)
    {
        using (Entities entities = new Entities())
        {
            var results = from o in entities.OrganizationSet
                          where o.Location.Id == l.Id
                          select o;
            return results.ToList<Organization>();
        }
    }

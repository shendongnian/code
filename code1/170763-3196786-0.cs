    public IQueryable<Profile> FindAllProfiles(string CountryFrom, string CountryLoc)
    {
        return db.Profiles.Where(p =>
            {
                p.ContryFrom != null &&
                p.CountryFrom.CountryName != null &&
                p.CountryFrom.CountryName.Equals(CountryFrom, StringComparison.OrdinalIgnoreCase)
            });
    }

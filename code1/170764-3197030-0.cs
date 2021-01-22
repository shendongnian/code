    class Example
    {
        public IQueryable<Profile> FindAllProfiles(string CountryFrom, string CountryLoc)
        {
            return db.Profiles.Where(p => p.MatchesCountry(CountryFrom, CountryLoc));
        }
    }
    public static class ProfileExtensions
    {
        public static bool MatchesCountry(this Profile profile, string CountryFrom, string CountryLoc)
        {
            // define your logic here
        }
    }

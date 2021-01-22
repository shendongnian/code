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
            // NOTE: Your comparison logic goes here.  Below is an example implementation
            // if the CountryFrom parameter was specified and matches the profile's CountryName property
            if(!string.IsNullOrEmpty(CountryFrom) && string.Equals(profile.CountryName, CountryFrom, StringComparison.OrdinalIgnoreCase))
                return true; // then a match is found
            // if the CountryLoc parameter was specified and matches the profile's CountryCode property
            if (!string.IsNullOrEmpty(CountryLoc) && string.Equals(profile.CountryCode, CountryLoc, StringComparison.OrdinalIgnoreCase))
                return true; // then a match is found
            // otherwise, no match was found
            return false;
        }
    }

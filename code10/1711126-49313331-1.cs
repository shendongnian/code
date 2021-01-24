    public class CountryList
    {
        private CultureTypes _AllCultures;
        public CountryList(bool AllCultures)
        {
            this._AllCultures = (AllCultures) ? CultureTypes.AllCultures : CultureTypes.SpecificCultures;
            this.Countries = GetAllCountries(this._AllCultures);
        }
        public List<CountryInfo> Countries { get; set; }
        public List<CountryInfo> GetCountryInfoByName(string CountryName, bool NativeName)
        {
            return (NativeName) ? this.Countries.Where(info => info.Region.NativeName == CountryName).ToList()
                                : this.Countries.Where(info => info.Region.EnglishName == CountryName).ToList();
        }
        public List<CountryInfo> GetCountryInfoByName(string CountryName, bool NativeName, bool IsNeutral)
        {
            return (NativeName) ? this.Countries.Where(info => info.Region.NativeName == CountryName && 
                                                               info.Culture.IsNeutralCulture == IsNeutral).ToList()
                                : this.Countries.Where(info => info.Region.EnglishName == CountryName && 
                                                               info.Culture.IsNeutralCulture == IsNeutral).ToList();
        }
        public string GetTwoLettersName(string CountryName, bool NativeName)
        {
            CountryInfo country = (NativeName) ? this.Countries.Where(info => info.Region.NativeName == CountryName)
                                                               .FirstOrDefault()
                                               : this.Countries.Where(info => info.Region.EnglishName == CountryName)
                                                               .FirstOrDefault();
            return (country != null) ? country.Region.TwoLetterISORegionName : string.Empty;
        }
        public string GetThreeLettersName(string CountryName, bool NativeName)
        {
            CountryInfo country = (NativeName) ? this.Countries.Where(info => info.Region.NativeName.Contains(CountryName))
                                                                .FirstOrDefault()
                                               : this.Countries.Where(info => info.Region.EnglishName.Contains(CountryName))
                                                                .FirstOrDefault();
            return (country != null) ? country.Region.ThreeLetterISORegionName : string.Empty;
        }
        public List<string> GetIetfLanguageTag(string CountryName, bool NativeName)
        {
            return (NativeName) ? this.Countries.Where(info => info.Region.NativeName == CountryName)
                                                .Select(info => info.Culture.IetfLanguageTag).ToList()
                                : this.Countries.Where(info => info.Region.EnglishName == CountryName)
                                                .Select(info => info.Culture.IetfLanguageTag).ToList();
        }
        public List<int> GetRegionGeoId(string CountryName, bool NativeName)
        {
            return (NativeName) ? this.Countries.Where(info => info.Region.NativeName == CountryName)
                                                .Select(info => info.Region.GeoId).ToList()
                                : this.Countries.Where(info => info.Region.EnglishName == CountryName)
                                                .Select(info => info.Region.GeoId).ToList();
        }
        private static List<CountryInfo> GetAllCountries(CultureTypes cultureTypes)
        {
            List<CountryInfo> Countries = new List<CountryInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(cultureTypes))
            {
                if (culture.LCID != 127)
                    Countries.Add(new CountryInfo()  { 
                        Culture = culture, 
                        Region = new RegionInfo(culture.TextInfo.CultureName) 
                    });
            }
            return Countries;
        }
        public class CountryInfo
        {
            public CultureInfo Culture { get; set; }
            public RegionInfo Region { get; set; }
        }
    }

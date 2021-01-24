    As @ADyson said in his comment there is lot of documentation out there to help you educate and implement the scenario you mentioned. 
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    //Creating a Class object with all the properties of json string
    public class CountriesInfo
    {
        public string type { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public string mcc { get; set; }
        public string mnc { get; set; }
        public string brand { get; set; }
        public string @operator { get; set; }
        public string status { get; set; }
        public string bands { get; set; }
        public string notes { get; set; }
    }
      static void Main(string[] args)
        {
            var strCountriesList = File.ReadAllText(@"YourJSONFilePath");
            JArray countriesInfoListArray = JArray.Parse(strCountriesList);
            List<CountriesInfo> countriesInfoList = countriesInfoListArray.Select(p => new CountriesInfo()
            {
                type = (string) p["type"],
                countryName = (string) p["countryName"],
                countryCode = (string) p["countryCode"],
                mcc = (string) p["mcc"],
                mnc = (string) p["mnc"],
                brand = (string) p["brand"],
                @operator = (string) p["@operator"],
                status = (string) p["status"],
                bands = (string) p["bands"],
                notes = (string) p["notes"]
            }).ToList();
           // Filters the countries based on the countryName (since the country name has null I am checking for null in countryName
            var filteredCountries =  countriesInfoList.Where(p => p.countryName != null && p.countryName.Equals("CountryYouWantToFilter"));
            foreach (var countryInfo in filteredCountries)
            {
               //do something with the countryInfo as shown below
                var strOperator = countryInfo.@operator;
                var status = countryInfo.status; 
            }

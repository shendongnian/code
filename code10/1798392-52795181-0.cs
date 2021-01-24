    namespace WebApp.Models
    {
        public class CountryList
        {
            public byte Id { get; set; }
            public string name { get; set; } //country name
            //public DefaultModel DefaultModel { get; set; }
        }
        public class CountryListViewModel
        {
            public string CountryLists { get; set; }
            public List<CountryList> CountryList { get; set; }
        }
    }

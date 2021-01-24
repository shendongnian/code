    public class County
    {
        public string CountyName { get; set; }
        public List<string> CommonMisspellings { get; set; }
    
        public County()
        {
            CommonMisspellings = new List<string>();
        }
    }

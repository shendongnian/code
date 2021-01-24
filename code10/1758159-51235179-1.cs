    public class Company
    {
        public int Id { get; set; }
        private string _website;
        public string Website 
        { 
            get { return _website; }
            set { _website = value ?? string.Empty; }
        };
        public Company ()
        {
            _website = string.empty;
        }
    }

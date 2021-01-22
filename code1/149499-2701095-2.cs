    public class SomeObject
    {
        private string _title = "";
    
        public string Title { get { return _title; } set { _title = value; } }
    }
    // Or with Auto-Properties
    public class SomeObjectAutoProperties
    {
        public string Title { get; set; }
    }

    public class MyModel
    {
        private string _title;
        public int Order {get;set;}
    
        public string Title { get => _title.ToUpper(); set => _title = value.ToUpper(); }
    }
    

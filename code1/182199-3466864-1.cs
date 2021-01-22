    public class MyDisplayName : DisplayNameAttribute
    {
        public int DbId { get; set; }
    
        public MyDisplayName(int DbId)
        {
            this.DbId = DbId;
        }
    
    
        public override string DisplayName
        {
            get
            {
                // Do some db-lookup to retrieve the name
                return "Some string from DBLookup";
            }
        }
    }
    
        public class TestModel
        {
            [MyDisplayName(2)]
            public string MyTextField { get; set; }
        }

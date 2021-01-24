    public class ARCustomers
    {
        public ARCustomers()
        {
             CustomerOptionalFieldValues = new Dinctionary<string, object>();
        }
    
        public string CustomerNumber { get; set; }
        public string ShortName { get; set; }
        .....
        public Dictionary<string, object> CustomerOptionalFieldValues { get; set; }
    
    }

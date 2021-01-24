    public class Resource {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientIntID { get; set; }
        public string ClientCreatedDate { get; set; }
    }
    
    public class RootObject{
        public List<Resource> resource { get; set; }
    }

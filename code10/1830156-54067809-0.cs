    public class owner {
        public int id {get;set;}
        public string name {get;set;}
        public string country {get;set}
    }
    public class pet {
        public int id { get; set; }
        public string animal { get; set; }
        public string name { get; set; }
        public int owner_id { get; set; } 
    }
    public class user {
        public int id {get;set;}
        public List<owner> owners {get;set;}
        public List<pet> pets {get;set}
    }

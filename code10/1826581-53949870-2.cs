    interface IIDBase {
        int Id { get; set; }
        string Name { get; set; }
        string PhoneNo { get; set; }
    }
    
    public class Customer {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
    
    public class Products : IIDBase {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        // ...
    }

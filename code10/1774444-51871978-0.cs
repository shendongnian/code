    class Order
    {
        public int Id {get; set;}
        // every order has zero or more requests (one-to-many)
        public virtual ICollection<Request> Requests {get; set;}
        public string Name {get; set;}
        ...
    }
    class Request
    {
        public int Id {get; set;}
        // Every Request belongs to exactly one Order using foreign key
        public int OrderId {get; set;} 
        public virtual Order Order {get; set;}
        public string Name {get; set;}
        ...        
    }

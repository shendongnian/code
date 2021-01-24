    interface IId
    {
        public int Id {get;}
    }
    class Customer : IId
    {
        public int Id {get; set; }
        ...
    }  
    class Order : IId
    {
        public int Id {get; set; }
        ...
    }   

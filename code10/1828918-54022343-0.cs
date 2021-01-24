    class A
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
    }
    
    class B
    {
        public string A1 { get; set; }
        public string A3 { get; set; }
        public string B1 { get; set; }
    
        public B(A instance)
        {
           this.A1 = instance.A1;
        }
    }

    interface IBComposite
    {
        int ID {get;}
        string Name {get;set;}
    }
    
    interface ICComposite
    {
        string Name {get;set;}
    }
    
    class D : IBComposite, ICComposite
    {
        public int ID {get; set;}
        public string Name {get; set;}
    }
    
    class B
    {
        private IBComposite myD;
        public B( IBComposite d ){ myD = d; }
        // Will "see" ID and Name on "myD"
    }
    
    class C
    {
        private ICComposite myD;
        public C( ICComposite d ){ myD = d; }
        // Will "see" only Name on "myD"
    }

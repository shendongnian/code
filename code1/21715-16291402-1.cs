    public Foo
    {
        public Foo()
        {
            this.InitializeObject();
        }
    
        public Foo(int arg) : this()
        {
            // do something with Foo's arg
        }
    
        protected virtual void InitializeObject()
        {
            // initialize object Foo
        }
    }
    
    public Bar : Foo
    {
        public Bar : base() { }
    
        public Bar(int arg) : base(arg)
        {
           // do something with Bar's arg
        }
    
        protected override void InitializeObject()
        {
           // initialize object Bar
        
           base.InitializeObject();
        }
    }

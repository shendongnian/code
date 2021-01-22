    internal MyReadOnlyClass : IReadOnlyClass, IMutableClass
    {
        public string SomeProperty { get; set; }
        public int Foo()
        {
            return 4; // chosen by fair dice roll
                      // guaranteed to be random
        }
        public void Foo( int arg )
        {
            this.SomeProperty = arg.ToString();
        }
    }
    public SomeClass
    {
        private MyThing = new MyReadOnlyClass();
        public IReadOnlyClass GetThing 
        { 
            get 
            { 
                return MyThing as IReadOnlyClass;
            }
        }
        public IMutableClass GetATotallyDifferentThing
        {
            get
            {
                return MyThing as IMutableClass
            }
        }
    }

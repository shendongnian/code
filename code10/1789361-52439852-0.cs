    class Foo
    {
        protected Bar _someBar;
        public Foo()
        {
            _someBar = new Bar();
           InitBar();
        }
        protected void InitBar()
        {
            _someBar.SomeImportentMethod();
        }
    }
    class Baz : Bar
    {
        private int _id:
        public Baz(int id) : base()
        {
             _id = id;
        }
        
        protected override InitBaz()
        {
           base.InitBaz();
            _someBaz.Id = _id;
        }
    }

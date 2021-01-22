    class FooBarFactory
    {
        private static _id = 0;
        public FooBar MakeAFooBar()
        {
            FooBar foo = new FooBar();
            foo.ID = _id;
            _id++;
        }
    }
    class FooBar
    {
        public int ID {get;set;}
    }

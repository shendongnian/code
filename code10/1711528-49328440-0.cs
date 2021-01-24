    class Y
    {
        public Action<object> SomeDelegate { get; set; }
    }
    
    class B
    {
        public static void SomeMethod(Y y, object o)
        {
            //...
        }
    }
    
    var y = new Y();
    y.SomeDelegate = (o) => B.SomeMethod(y, o);

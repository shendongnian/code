    interface ISomeClassUser<X>
    {
        X Use<T>(SomeClass<T> s);
    }
    interface ISomeClassUser
    {
        void Use<T>(SomeClass<T> s);
    }
    interface ISomeClass
    {
        X Apply<X>(ISomeClassUser<X> user);
        void Apply(ISomeClassUser user);
    }
    class SomeClass<T> : ISomeClass
    {
        public T ValueINeed { get; set; }
        public X Apply<X>(ISomeClassUser<X> user) { return user.Use(this); }
        public void Apply(ISomeClassUser user) { user.Use(this); }
    }
    // Assumes you want to get a string out, use a different generic type as needed
    class XmlUser : ISomeClassUser<string>
    {
        public string Use<T>(SomeClass<T> s)
        {
            string str = "";
            // do your conditional formatting here, branching on T as needed
            // ...
            return str;
        }
    }
    class ClassThatHasListOfGenericObjects
    {
        List<ISomeClass> _l = new List<ISomeClass>();
        XmlUser user = new XmlUser();
        public string SomeMethod()
        {
            string s = "";
            foreach (ISomeClass i in _l)
            {
                s += i.Apply(user);
            }
            return s;
        }
    }

    abstract class A
    {
        public A()
        {
        }
    }
    class B : A
    {
        // I know, its trivial, but it does the same ...
        public B(string name) : base()
        {
            Name = name;
        }
        public string Name { set; get; }
    }

    public class Container
    {
        public A A { get; private set; }
        public B B { get; private set; }
        public C C { get; private set; }
    
        public bool StoreIfKnown(object obj)
        {
            switch (obj)
            {
                case A a:
                    this.A = a
                    // I don't put "break" because I'm returning value from a method
                    return true;
                case B b:
                    this.B = b
                    return true;
                case C c:
                    this.C = c
                    return true;
                default:
                    WriteLine("<other>");
                    return false;
            }
        }
    }

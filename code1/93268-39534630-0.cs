    public class Container
    {
        public A A { get; private set; }
        public B B { get; private set; }
        public C C { get; private set; }
    
        public bool StoreIfKnown(object o)
        {
            switch (0)
            {
                case A a:
                    this.A = a
                    break;
                case B b:
                    this.B = b
                    break;
                case C c:
                    this.C = c
                    break;
                default:
                    WriteLine("<other>");
                    break;
            }
        }
    }

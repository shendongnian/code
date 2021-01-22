    public class A
    {
        private DTO _d;
        // New constructor.
        protected A(DTO d)
        {
            _d = d;
        }
        // Old constructor calls new constructor.
        public A() : this(new DTO())
        {
        }
        public DTO D
        {
            get { return _d; }
            set { _d = value; }
        }
    }
    public class B : A
    {
        // Old B constructor calls new A constructor.
        public B() : base(new MyDTO())
        {
        }
        new public MyDTO D
        {
            // Getting D casts A.D instead of using an object exclusive to B.
            get { return (MyDTO)base.D; }
            set { base.D = value; }
        }
    }

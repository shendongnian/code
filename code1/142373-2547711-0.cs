    class A
    {
        public virtual C Argument { get; set; }
    }
    class B : A
    {
        D argument = null;
        public override C Argument
        {
            get
            {
                return argument;
            }
            set
            {
                if (value is D)
                {
                    argument = (D)value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
    class C
    {
    }
    class D : C
    {
    }
...
    static void Main()
    {
        B b = new B();
        D arg = new D();
        b.Argument = arg;
    }

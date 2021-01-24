    class MyBase : IFoo, IBar
    {
        Base innerValue;
        public static implicit operator Base(MyBase value)
        {
            return value.innerValue;
        }
        public static implicit operator MyBase(Derived1 value)
        {
            return new MyBase(value);
        }
        public static implicit operator MyBase(Derived2 value)
        {
            return new MyBase(value);
        }
        
        public MyBase(Derived1 value)
        {
            innerValue = value;
        }
        public MyBase(Derived2 value)
        {
            innerValue = value;
        }
        // Implement IFoo and IBar based on innerValue calls
    }

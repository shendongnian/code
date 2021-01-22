    public class Base
    {
        protected int m_value;
        ...
        // From int
        public static implicit operator Base(int Value)
        {
            Base newObject = new Base();
            newObject.FromInt(Value);
            return newObject;
        }
        ...
        // To string
        public static explicit operator string(Base Value)
        {
            return String.Format("${0:X6}", (int)Value);
        }
        //Instance FromInt()
        protected void FromInt(int value)
        {
            m_value = value;
        }
    }
    public class Derived : Base
    {
        // To string, re-use Base-ToString
        public static explicit operator string(Derived Value)
        {
            // Cast (Derived)Value to (Base)Value and use implemented (Base)toString
            return (string)(Base)Value;
        }
        // Use FromInt, which has access to instance variables
        public static implicit operator Base(int Value)
        {
            // We can't use (Base)obj = Value because it will create
            // a "new Base()" not a "new Derived()"
            Derived newObject = new Derived();
            newObject.FromInt(Value);
            return newObject;
        }
    }

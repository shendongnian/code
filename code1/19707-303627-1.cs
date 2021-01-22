    public class SomeClass
    {
        public static implicit operator SomeOtherClass(SomeClass sc)
        {
            //replace with whatever conversion logic is necessary
            return new SomeOtherClass()
            {
                foo = sc.foo,
                bar = sc.bar
            }
        }
        public static implicit operator SomeClass(SomeOtherClass soc)
        {
            return new SomeClass()
            {
                foo = soc.foo,
                bar = soc.bar
            }
        }
        //rest of class here
    }

    public abstract class BaseClass
    {
        private BaseClass() { }
    
        public class SubClass1 : BaseClass
        {
            public SubClass1() : base() { }
        }
    
        public class SubClass2 : BaseClass
        {
            public SubClass2() : base() { }
        }
    }

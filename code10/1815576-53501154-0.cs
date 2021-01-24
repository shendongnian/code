    class Overflow
    {
      
    
        public class BaseO
        {
            protected class PrivateO
            {
                public int foo;
            }
            protected PrivateO GetPrivate() 
            {
                return new PrivateO();
            }
        }
    
        public class ChildO : BaseO
        {
            private int foo;
            public ChildO()
            {
                this.foo = GetPrivate().foo; // <- desired behavior
            }
        }
    }

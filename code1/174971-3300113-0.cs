    public class Outer
    {
        private class Inner : IEnumerable<Foo>
        {
            /* Presumably this class contains some functionality which Outer needs
             * to access, but which shouldn't be visible to callers 
             */
        }
    
        public IEnumerable<Foo> GetFoos()
        {
            return new Inner();
        }
    }

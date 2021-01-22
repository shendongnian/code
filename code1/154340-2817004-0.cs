    public interface IN
    {
        int Field1 { get; }
    }
    
    public class E
    {
        public void Foo()
        {
            N n = new N();
            n.Field1 = 42;
        }
    
        private class N : IN
        {
            private int _field1;
    
            public int Field1
            {
                get { return _field1; }
                set { _field1 = value; }
            }
        }
    }

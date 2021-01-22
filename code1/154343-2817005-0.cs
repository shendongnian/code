    public class E
    {
        public void Foo()
        {
          IN n = new N();
          n.Field1 = 42;
        }
        public class N : IN
        {
            private int _field1;
            
            int IN.Field1
            {
                get { return _field1; }
                set { _field1 = value; }
            }
        }
        
        private interface IN
        {
            int Field1 { get; set; }
        }
    }

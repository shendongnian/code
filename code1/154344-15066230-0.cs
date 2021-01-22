    public class E
    {
        public void Foo()
        {
          IN n = new N();
          n.field1 = 42;
        }
    
        class N : IN
        {
            public int _field1;
        }
    }

    public class A
    {
        public string field1;
        public string field2;
        public A(A copyFrom)
        {
            this.field1 = copyFrom.field1;
            this.field2 = copyFrom.field2;
        }
    }
    
    public class B : A
    {
        public string field3;
        
        public B(A source)
            : base(source)
        {
        }
    }

    public class A
    {
        public string field1;
        public string field2;
    
        public A(string field1, string2 field2)
        {
             this.field1 = field1;
             this.field2 = field2;
        }
    }
    
    public class B : A
    {
        public string field3;
        public B(string field1, string2 field2, string field3)
            : base(field1, field2)
        {
            this.field3 = field3;
        }
    }

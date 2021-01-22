    public class A
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
    
    public class B
    {
        public A A { get; set; }
        public string Field3 { get; set; }
        public B(A a) { this.A = a; }
    }

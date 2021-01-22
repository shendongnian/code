    public class A
    {
        private B b;
        public A(B b)
        {
              this.b = b;
        }
    }
    // Then you can have:
    B b1 = new B();
    A a1 = new A(b1); // here's the link
    
    B b2 = new B();
    A a2 = new A(b2); // and another link

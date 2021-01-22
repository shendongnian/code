    public class B
    {
        B(int i) {A = new A(i);}
        public A A {get; set;}
    }
    ...
    void Main()
    {
        B b1 = new B(1);
        A a2 = new A(2);
        b1.A = a2;
    }

    public class A
    {
        public A(Action<A> myAction)
        {
            myAction(this);
        }
    }
    public class B
    {
        public B()
        {
            var myA = new A((a) => { DoSomethingWithA(a); });
        }
        public void DoSomethingWithA(A a)
        {
        }
    }
 

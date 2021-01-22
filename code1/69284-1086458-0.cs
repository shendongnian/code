    public class A<T> where T : B
    {
        public void Method(Func<T> ctor)
        {
            T obj = ctor();
            // ....
        }
    }
    // elsewhere...
    public class C : B
    {
        public C(object obj) {}  
    }
    public void DoStuff()
    {
        A<C> a = new A<C>();
        object ctorParam = new object();
        a.Method(() => new C(ctorParam));
    }
    
    

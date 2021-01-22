    using System;
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            CreateB(a);
    
            WeakReference weakRef = new WeakReference(a);
            CreateB(weakRef);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.KeepAlive(a);
            GC.KeepAlive(weakRef);
    
            Console.ReadKey();
        }
    
        private static void CreateB(A a)
        {
            B b = new B(a);
        }
        private static void CreateB(WeakReference a)
        {
            B b = new B(a);
        }
    }
    
    class A
    { }
    
    class B
    {
        private WeakReference a;
        public B(WeakReference a)
        {
            this.a = a;
        }
        public B(A a)
        {
            this.a = new WeakReference(a);
        }
    
        ~B()
        {
            Console.WriteLine("a.IsAlive: " + a.IsAlive);
            Console.WriteLine("a.Target: " + a.Target);
        }
    }

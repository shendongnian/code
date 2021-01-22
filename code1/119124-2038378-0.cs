    interface IFoo { }
    class Bar : IFoo { }
    class Test {
        public void DoWork(IFoo a) { }
        public void DoWork(Bar b) { }
    }
    
    class Program {
        static void Main(string[] args) {
            IFoo a = new Bar();
            Test t = new Test();
            t.DoWork(a);
        }
    }

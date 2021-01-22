    abstract class A
    {
        protected abstract int X { get; }
        public void DoStuff() {
            Console.WriteLine(X);
        }
    }
    class B : A
    {
        protected override int X { get { return 1; } }
    }

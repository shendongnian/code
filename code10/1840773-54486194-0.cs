    class Decorator : Base
    {
        private Base b;
        public Decorator(Base b)
        {
            this.b = b;
            b.Event -= b.Method2;
            b.Event += Method2;
        }
        public override void Method1() { }
        public override void Method2() { Console.WriteLine("Decorator Method2 call"); }
        public override void OnEventInvoke()
        {
            b.OnEventInvoke();
        }
    }

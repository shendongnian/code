    class SpecialDerived : Base
    {
        public override void Say()
        {
            Console.WriteLine("Called from Special Derived.");
            base.Say();
        }
    }

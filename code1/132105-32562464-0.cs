    class SpecialDerived : Derived
    {
        public override void Say()
        {
            Console.WriteLine("Called from Special Derived.");
            var ptr = typeof(Base).GetMethod("Say").MethodHandle.GetFunctionPointer();            
            var baseSay = (Action)Activator.CreateInstance(typeof(Action), this, ptr);
            baseSay();            
        }
    }

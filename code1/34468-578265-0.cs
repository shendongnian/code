    abstract class Foo {
        public void F() {
            Console.WriteLine(ToString()); // Always a virtual call!
        }
    
        public override string ToString() { System.Diagnostics.Debug.Assert(false); }
    };
    
    sealed class Bar : Foo {
        public override string ToString() { return "I'm called!"; }
    }

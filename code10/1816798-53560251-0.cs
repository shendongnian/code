    public class C1 {
        private void AImplementation() { Console.WriteLine("Good"); }
        public virtual void A() { AImplementation(); }
        public void B() { AImplementation(); }
    }
    public class C2 : C1 {
        public override void A() { B(); }
    }

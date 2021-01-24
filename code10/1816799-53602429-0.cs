    public class C1 {
        public virtual void A() { Console.WriteLine("Good"); }
        public void B() { A(); }
    }
    public class C2 : C1 {
        public override void A()
        {
            var method = new System.Diagnostics.StackTrace()
                        .GetFrames().Skip(1).Select(f => f.GetMethod())
                        .FirstOrDefault(m => m.Name == nameof(A) && m.DeclaringType == typeof(C2));
            if (method == null) B();
            else base.A();
        }
    }

      public class A
    {
        public virtual void DoIt()
        {
            Console.WriteLine("A::DoIt()");
        }
    }
    public class B : A
    {
        new public void DoIt()
        {
            Console.WriteLine("B::DoIt()");
        }
    }
    public class C : A
    {
        public override void DoIt()
        {
            Console.WriteLine("C::DoIt()");
        }
    }

    class B
    {
      public virtual void M() { Console.WriteLine("B.M"); }
    }
    class D : B
    {
      public override void M() { Console.WriteLine("D.M"); }
      public void BM() { base.M(); }
    }
    ...
    D d = new D();
    d.M(); // D.M
    d.BM(); // B.M

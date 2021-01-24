    class W2 : IW
    {
      public void C() { Console.WriteLine("W2C"); } // NOT VIRTUAL
    }
    class P2 : W2, IP
    {
      public new void C() { Console.WriteLine("P2C"); }
      public virtual void D() { Console.WriteLine("P2D"); }
    }

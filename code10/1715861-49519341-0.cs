    interface IW
    {
      void C();
    }
    interface IP : IW
    {
      void D();
    }
    class W : IW
    {
      public virtual void C() { Console.WriteLine("WC"); }
    }
    class P : W, IP
    {
      public override void C() { Console.WriteLine("PC"); }
      public virtual void D() { Console.WriteLine("PD"); }
    }
    ...
    IP ip = new P();
    ip.C(); // PC
    IW iw = new P();
    ip.C(); // PC

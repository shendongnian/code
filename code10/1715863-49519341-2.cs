    class P3 : P2
    {
      public new void C() { Console.WriteLine("P3C"); }
    }
    ...
    IP ip = new P3();
    ip.C();
    IW iw = new P3();
    ip.C();

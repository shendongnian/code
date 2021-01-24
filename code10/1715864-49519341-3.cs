    class P4 : P2, IP // NOTE IP
    {
      public new void C() { Console.WriteLine("P4C"); }
    }
    ...
    IP ip = new P4();
    ip.C();
    IW iw = new P4();
    ip.C();

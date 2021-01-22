    interface IA {
      string P1;
      string P2;
    }
    interface IB {
      string P3;
      string P4;
    }
    class A : IA {
      string P1 { get; set; }
      string P2 { get; set; }
    }
    class B : IB {
      string P3 { get; set; }
      string P4 { get; set; }
    }
    class C : IA, IB {
      string P1 { get; set; }
      string P2 { get; set; }
      string P3 { get; set; } 
      string P4 { get; set; }
    }

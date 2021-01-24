    class A { public int P { get; set; } }
    class B { public int P2 { get; set; } }
   
    var a = new A { P = 5 };
    var b = new B { P2 = 10 };
    Swap(() => a.P, () => b.P2);

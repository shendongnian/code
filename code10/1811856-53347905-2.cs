    class A { public int P { get; set; } }
    class B { public int P2 { get; set; } }
   
    var a = new A();
    var b = new B();
    Swap(() => a.P, () => b.P2);

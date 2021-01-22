    public class A { int prop { get; set; } }
    public class B { int prop { get; set; } }
    ...
      A obja = new A();
      B objb = (B)obja;  // CS0029

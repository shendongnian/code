    public class A { int prop { get; set; } }
    public class B { int prop { get; set; } }
    ...
      A obja = new A();
      B objb = (A)obja;  // CS0029

    class Program {
      static void Main(string[] args) {
        dynamic test = new JsonNull();
        Fails(test);
      }
      static void Fails(IFoo ifoo) { }
    }
    // ...

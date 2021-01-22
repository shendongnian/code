    public static void Main()
    {
      var test = new Test();
      test.DoSomething(); // Compiler binds to the implicit implementation.
      var a = (IA)test;
      a.DoSomething(); // Compiler binds to the IA implementation.
      var b = (IB)test;
      b.DoSomething(); // Compiler binds to the IB implementation.
    }

    public static void Main()
    {
      Object a = new Object();
      Console.WriteLine("object created");
      DoSomething(a);
      Console.WriteLine("object used");
      a = null;
      Console.WriteLine("reference set to null");
    }

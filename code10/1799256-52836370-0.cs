    static void M1(int n)
    {
      float i = n; // actual conversion at run-time
      Console.WriteLine(i);
    }
    static void M2(float f)
    {
      float i = f; // same types
      Console.WriteLine(i);
    }

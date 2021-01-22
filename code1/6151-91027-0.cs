    static void Main (string [] args)
    {
      float
        a = float.MaxValue / 3.0f,
        b = a * a;
      if (a * a < b)
      {
        Console.WriteLine ("Less");
      }
      else
      {
        Console.WriteLine ("GreaterEqual");
      }
    }

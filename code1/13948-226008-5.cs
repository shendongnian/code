    static int plusplus(ref int x)
    {
      int xOld = x;
      x++;
      return xOld;
    }
    static void Main(string[] args)
    {
        int x = 10;
        x = plusplus(x);
        Console.WriteLine(x);
    }

    static int[] sums = new int[] {1, 3, 6, 10, 15, 21, 28, 36, 45};
    static int[] products = new int[] {1, 2, 6, 24, 120, 720, 5040, 40320, 362880};
    static void Main(string[] args)
    {
      var pans = 0;
      for (var i = 123456789; i <= 123987654; i++)
      {
        var num = i.ToString();
        if (Sum(num) == sums[num.Length - 1] && Product(num) == products[num.Length - 1])
          pans++;
      }
      Console.WriteLine(pans);
    }
    protected static int Sum(string num)
    {
      int sum = 0;
      foreach (char c in num)
        sum += (int) (c - '0');
      return sum;
    }
    protected static int Product(string num)
    {
      int prod = 1;
      foreach (char c in num)
        prod *= (int)(c - '0');
      return prod;
    }

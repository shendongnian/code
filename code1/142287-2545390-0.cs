    public static class Math
    {
      public static int GCD(int a, int b)
      {
         return b == 0 ? a : GCD(b, a % b);
      }
      // Implement the System.Math methods
      public static double Pow(double x, double y)
      {
        return System.Math.Pow(x, y);
      }
      // etc.
    }

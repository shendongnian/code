    public static IEnumerable<int> GetDigits(int num)
    {
       do { yield return num % 10; } while ((num /= 10) > 0);
    }
    
    public static bool SomeWeirdMathsOp(int num)
    {
       var result = GetDigits(num)
          .Sum(value => (int)Math.Pow(value, 3));
    
       return result == num;
    }

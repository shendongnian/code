    public static IEnumerable<int> GetDigits(int num)
    {
       do { yield return num % 10; } while ((num /= 10) > 0);
    }
    
    public static bool SomeWeirdMathsOp(int num)
    {
       return num == GetDigits(num).Sum(x => (int)Math.Pow(x, 3));
    }

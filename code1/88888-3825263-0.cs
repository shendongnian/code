    public static int Factorial(this int count)
    {
            return count == 0
                       ? 1
                       : Enumerable.Range(1, count).Aggregate((i, j) => i*j);
    }
    3.Factorial() == 6

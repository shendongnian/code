    public static class MyMathFunctions
    {
        IEnumerable<double> SquareArea(this IEnumerable<int> xs)
        {
            return xs.Select(r => 2 * Math.PI * r);
        }
    
        IEnumerable<double> SquareArea(this IEnumerable<int> xs)
        {
            return xs.Select(r => 2 * Math.PI * r);
        }
    
    }

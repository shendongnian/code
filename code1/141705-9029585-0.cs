    public static void CreatingExpressionTree()
    {
        ParameterExpression parameter1 = Expression.Parameter(typeof(int), "x");
        BinaryExpression multiply = Expression.Multiply(parameter1, parameter1);
        Expression<Func<int, int>> square = Expression.Lambda<Func<int, int>>(
            multiply, parameter1);
        Func<int, int> lambda = square.Compile();
        Console.WriteLine(lambda(5));
    }

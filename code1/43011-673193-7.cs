    public static void DoSomethingExpression(string[] names, System.Linq.Expressions.Expression<Func<string, bool>> myExpression)
    {
        Console.WriteLine("Lambda used to represent an expression");
        BinaryExpression bExpr = myExpression.Body as BinaryExpression;
        if (bExpr == null)
            return;
        Console.WriteLine("It is a binary expression");
        Console.WriteLine("The node type is {0}", bExpr.NodeType.ToString());
        Console.WriteLine("The left side is {0}", bExpr.Left.NodeType.ToString());
        Console.WriteLine("The right side is {0}", bExpr.Right.NodeType.ToString());
        if (bExpr.Right.NodeType == ExpressionType.Constant)
        {
            ConstantExpression right = (ConstantExpression)bExpr.Right;
            Console.WriteLine("The value of the right side is {0}", right.Value.ToString());
        }
     }

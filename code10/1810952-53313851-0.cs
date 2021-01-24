    public static string AddSpaceBeforeAndAfterOperator(string expression)
    {
        var operators = new List<string> { "=", "!", "<", ">", ">=", "<=", "!=", "||", "&&" };
        foreach (var op in operators)
        {
            expression = expression.Replace(op, " " + op + " ");
        }
        return expression;
     }

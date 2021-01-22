    public static bool Validate<T>(this T o, IList<IEval<T>> conditions)
    {
        return conditions
            .Skip(1)
            .Aggregate(
                conditions.First().Expression(o),
                (a, b) => operators[b.Operator](a, b.Expression(o))
            );
    }
    
    public static Dictionary<Operator, Func<bool, bool, bool>> operators = new Dictionary<Operator, Func<bool, bool, bool>>()
    {
        {Operator.And, (a, b) => a && b},
        {Operator.Or, (a, b) => a || b}
    }

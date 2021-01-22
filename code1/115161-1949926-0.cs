    public static bool Validate<T>(this T o, IList<IEval<T>> conditions)
    {
        return conditions
            .Skip(1)
            .Aggregate(
                conditions.First().Expression(o),
                (a, b) => b.Operator == Operators.Or ? (a || b.Expression(o)) : (a && b.Expression(o))
            );
    }

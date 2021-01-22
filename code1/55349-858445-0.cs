    public void Method1(TProperty valueToCompare) : this(x => valueToCompare)
    {
         Expression constant = Expression.Constant(valueToCompare,
                                                   typeof(TProperty));
         ParameterExpression parameter = Expression.Parameter(typeof(T),
                                                              "t");
         Expression lambda = Expression.Lambda<Func<T, TProperty>> (constant,
                                                                    parameter);
         Method1(lambda);
    }

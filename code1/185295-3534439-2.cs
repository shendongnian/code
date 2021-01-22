    Ex x = new Ex(Expression.Parameter(typeof(double), "x"));
    Ex y = new Ex(Expression.Constant(10.0, typeof(double)));
    Ex z = x + y;
    Expression<Func<double, double>> result =
        Expression.Lambda<Func<double, double>>(z.Expression, x.Expression);

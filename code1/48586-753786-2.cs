    int x = 0;
    public void g()
    {
       bool greaterThan = f(i => i > 2, x);
       bool lessThan = f(i => i < 2, x);
    }
    public bool f(Func<int,bool> expression, int value)
    {
       return expression(value);
    }

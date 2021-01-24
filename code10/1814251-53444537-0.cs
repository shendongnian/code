    public void CallerMethod<S>(S y)
    {
        if (typeof(S).IsEnum)
        {
            ExampleMethod((int)y);
        }
    }
    

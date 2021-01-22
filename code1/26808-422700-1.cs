    public void OuterMethod(string parameter)
    {
        InnerMethodA(parameter);
    }
    
    public void OuterMethod(int parameter)
    {
        InnerMethodA(parameter);
    }
    private void InnerMethodA(object parameter)
    {
        // Whatever other implementation stuff goes here
        if (parameter is string)
        {
            InnerMethodB((string) parameter);
        }
        else if (parameter is int)
        {
            InnerMethodB((string) parameter);
        }
        else
        {
            throw new ArgumentException(...);
        }
    }
    private void InnerMethodB(string parameter)
    {
        // ...
    }
    
    private void InnerMethodB(int parameter)
    {
        // ...
    }

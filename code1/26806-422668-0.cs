    public void OuterMethod(object parameter)
    {
        if (parameter is int)
            InnerMethod((int)parameter);
        else if (parameter is string)
            InnerMethod((string)parameter);
        else
            throw new SomeKindOfException();
    }

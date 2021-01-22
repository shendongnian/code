    public void MyMethod(object caller)
    {
        myClass<T> test = caller as myClass<T>;
        if (test != null)
        {
             // Use test here
        }
    }

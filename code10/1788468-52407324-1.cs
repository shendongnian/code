    private void DoSomething<T, U>(KeyValuePair<T, U> a)
    {
        if (a.Key is int keyInt)
        {
            DoSomething(keyInt);
        }
        else if (a.Key is char keyChar)
        {
            DoSomething(keyChar);
        }
        else
        {
            throw new Exception("Unable to DoSomething to a.Key");
        }
    }

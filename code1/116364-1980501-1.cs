    Func<string, string> f = s => String.Format("Hello {0}", s);
    for (int i = 0; i < test.Count; i++)
    {
        test[i] = f(test[i]);
    }

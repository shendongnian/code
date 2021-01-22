    public void Foo(string x, object y, Stream z, int a)
    {
        CheckNotNull(x, y, z);
        ...
    }
    public static void CheckNotNull(params object[] values)
    {
        foreach (object x in values)
        {
            if (x == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

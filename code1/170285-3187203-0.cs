    [DllImport("one.dll", EntryPoint = "_test_mdl")]
    public static extern string _test_mdl1(string s);
    [DllImport("two.dll", EntryPoint = "_test_mdl")]
    public static extern string _test_mdl2(string s);
    public static string _test_mdl(string s)
    {
        if (condition)
            return _test_mdl1(s);
        else
            return _test_mdl2(s);
    }

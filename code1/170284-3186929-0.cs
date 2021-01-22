    static class OneInterop
    {
     [DllImport("one.dll")]
     public static extern string _test_mdl(string s);
    }
    
    static class TwoInterop
    {
     [DllImport("two.dll")]
     public static extern string _test_mdl(string s);
    }

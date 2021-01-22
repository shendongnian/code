    #if DEBUG
    public static string TestStringForDebugOnly(...)
    {
        ...
    }
    #endif
    // Arguments are only for illustration.
    public string CallingMethod(int id, string temp)
    {
        #if DEBUG
        string result = TestStringForDebugOnly(id, temp);
        #else
        string result = TestString(id, temp);
        #endif
        return result;
    }

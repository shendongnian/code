    1    public delegate void dlFuncToBeImplemented(string signal);
    2    public static event dlFuncToBeImplemented OnFuncToBeImplemented;
    3    public static void FuncToBeImplemented(string signal)
    4    {
    5         OnFuncToBeImplemented(signal);
    6    }

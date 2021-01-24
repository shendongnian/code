    1    public delegate void dlFuncToBeImplemented(int signal);
    2    public static event dlFuncToBeImplemented OnFuncToBeImplemented;
    3    public static void FuncToBeImplemented(int signal)
    4    {
    5         OnFuncToBeImplemented(signal);
    6    }

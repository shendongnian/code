    public static bool IsUnitTest { get; private set; } = true;
    [STAThread]
    public static void main()
    {
        IsUnitTest = false;
        ...
    }

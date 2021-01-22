    // Program.cs
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        if(MyLib.Condition1)
        {
            Application.Run(new Form1());
        }
        else if(MyLib.Condition2)
        {
            Application.Run(new Form2());
       }
    }
    // MyLib.cs
    ...
    public static bool Condition1
    {
        get
        {
             return resultOfLogicForCondition1;
        }
    }
    public static bool Condition2
    {
        get
        {
             return resultOfLogicForCondition2;
        }
    }

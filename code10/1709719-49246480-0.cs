    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            File.WriteAllText("hello.txt", "foo");
        }
        else
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

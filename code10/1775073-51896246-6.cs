    static class Program
    {
     [STAThread]
     static void Main()
     {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        KeySenderDemo ksd = new KeySenderDemo();
        //Application.Run(new Form1());
     }
    }

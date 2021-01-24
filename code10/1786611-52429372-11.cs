    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CustomForm.Start(new Form1(), new Form2(), new Form3());
            Application.Run();
        }
    }

    static class Program {
        public static Form1 TheForm;
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TheForm = new Form1();
            Application.Run(TheForm);
        }
    }

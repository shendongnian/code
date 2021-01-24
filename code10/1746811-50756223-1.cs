    static class Program
    {
        private static string restartArg =  "-restart";
        public static void Restart()
        {
            var startInfo = System.Diagnostics.Process.GetCurrentProcess().StartInfo;
            startInfo.FileName = Application.ExecutablePath;
            var exit = typeof(Application).GetMethod("ExitInternal",
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Static);
            exit.Invoke(null, null);
            startInfo.Arguments = restartArg;
            System.Diagnostics.Process.Start(startInfo);
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var restarted = Environment.CommandLine.Contains(restartArg);
            if (restarted)
                MessageBox.Show("Welcome back!");
            Application.Run(new Form1());
        }
    }

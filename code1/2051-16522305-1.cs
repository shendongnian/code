    static class Program
    {
        public static readonly SingleInstance Singleton = new SingleInstance(typeof(Program).FullName);
        [STAThread]
        static void Main(string[] args)
        {
            // NOTE: if this always return false, close & restart Visual Studio
            // this is probably due to the vshost.exe thing
            Singleton.RunFirstInstance(() =>
            {
                SingleInstanceMain(args);
            });
        }
        public static void SingleInstanceMain(string[] args)
        {
            // standard code that was in Main now goes here
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

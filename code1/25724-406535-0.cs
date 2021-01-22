        static Form1 mainForm = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] commandline)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program prog = new Program();
            prog.MainForm = mainForm = new Form1();
            prog.Run(commandline);
        }
        public Program()
        {
            this.IsSingleInstance = true;
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
            mainForm.Startup(eventArgs.CommandLine.ToArray());
        }

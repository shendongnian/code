        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string FullPath = Assembly.GetExecutingAssembly().Location;
            string ExeName = Path.GetFileNameWithoutExtension(FullPath);
            Type TypeBasedOnExeName = Assembly.GetExecutingAssembly().GetType(ExeName);
            Form StartupForm = (Form)Activator.CreateInstance(TypeBasedOnExeName);
            Application.Run(StartupForm);
        }

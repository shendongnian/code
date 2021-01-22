        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Initializer.Initialize();
            // it's now your responsibility to shut down the application !
            Application.Run();
        }

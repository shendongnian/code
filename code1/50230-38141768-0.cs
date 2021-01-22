    public static void appReloader()
        {
            //Start a new instance of the current program
            Process.Start(Application.ExecutablePath);
                
            //close the current application process
            Process.GetCurrentProcess().Kill();
        }

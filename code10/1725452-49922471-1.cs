    namespace Chat_Room 
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    //Need this, because if you do it in your Run method, appication will closes immediatly after you close the form.
                (new SceneOne()).Show(); 
                Application.Run(); 
            }
        }
    }

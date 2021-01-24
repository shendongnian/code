    namespace WindowsFormsApp1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                var container = GetContainer();
                // most likely the only resolve you need.
                var form = container.Resolve<Form1>();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(form);
            }
            private static IContainer GetContainer()
            {
               // Register Dependencies
               // Build the Container
               // return Container;
            }
        }
    }

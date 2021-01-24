        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Ensure the singleton WPF Application is instantiated
            if (System.Windows.Application.Current == null)
            {
                new App();
            }
            //Take control of WPF application shutdown
            System.Windows.Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
        }

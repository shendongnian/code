    public class MyApplicationContext : ApplicationContext {
        SplashForm splashForm;
        MainForm mainForm;
        public MyApplicationContext() {
            splashForm = new SplashForm();
            base.MainForm = splashForm;
        }
        
        public void RunApplication() {
            // This will show the splash screen
            ThreadPool.QueueUserWorkItem(new WaitCallback(MessageLoopThread));
            
            // This will perform any miscellaneous loading functions
            splashForm.PerformLoadingFunctions();
            if (!CheckLicensing()) {
                ShowErrorMessage();
                Application.Exit();
                return;
            }
            // Now load the main form
            mainForm = new MainForm();
            // We're done loading!  Swap out our objects
            base.MainForm = mainForm;
            // Close our splash screen
            splashForm.Close();
            splashForm.Dispose();
            splashForm = null;
        }
            
        private void MessageLoopThread(object o) {
            Application.Run(this);
        }
    }

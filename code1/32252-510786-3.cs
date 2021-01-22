    class SplashForm
    {
        //Delegate for cross thread call to close
        private delegate void CloseDelegate();
        //The type of form to be displayed as the splash screen.
        private static SplashForm splashForm;
        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.
            if (splashForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();           
        }
        static private void ShowForm()
        {
            splashForm = new SplashForm();
            Application.Run(splashForm);
        }
        static public void CloseForm()
        {
            splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
        }
        static private void CloseFormInternal()
        {
            splashForm.Close();
        }
    ...
    }

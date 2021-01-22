    public class UpdateController
    {
        private UserController _userController;
        private BackgroundWorker _backgroundWorker;
    
        public UpdateController(LoginController loginController, UserController userController)
        {
            _userController = userController;
            loginController.LoginEvent += Update;
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            _backgroundWorker.OnProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            _backgroundWorker.ReportsProgress = true;
        }
    
        public void Update()
        {
             _backgroundWorker.RunWorkerAsync();    
        }
    
        public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
            // Do the long-duration work here, and optionally
            // send the update back to the UI thread...
            int p = 0;// set your progress if appropriate
            object param = "something"; // use this to pass any additional parameter back to the UI
            _backgroundWorker.ReportProgress(p, param);
            }
        }
    
        // This event handler updates the UI
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update the UI here
    //        _userController.UpdateUsersOnMap();
        }
    }

    public class UpdateController
    {
        private UserController _userController;        
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public UpdateController(LoginController loginController, UserController userController)
        {
            _userController = userController;
            loginController.LoginEvent += Update;
        }
    
        public void Update()
        {                        
             // The while loop was unecessary here
             backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
             backgroundWorker.RunWorkerAsync();                 
        }
    
        public delegate void DoUIWorkHandler();
        
        
        public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           // You must check here if your are executing on a background thread.
           // UI operations are only allowed on the main application thread
           if (someControlOnMyForm.InvokeRequired)
           {
               // This is how you force your logic to be called on the main
               // application thread
               someControlOnMyForm.Invoke(new             
                          DoUIWorkHandler(_userController.UpdateUsersOnMap);
           }
           else
           {
               _userController.UpdateUsersOnMap()
           }
        }
    }

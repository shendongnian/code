    public class WorkControl
    {
        private MyProcess _myProcess;
    
        public WorkControl(MyProcess myProcess)
        {
            _myProcess = myProcess;  //Need to actually set it to an object
            _myProcess.InBoxShareDisconnected += HandleDisconnected;
        }
    
        private void HandleDisconnected(object sender, NetworkShareDisconnectedEventArgs e)
        {
            //Here you can access all the properties of "e"
        }
    }

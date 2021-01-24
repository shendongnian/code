    public class Proxy : MarshalByRefObject
    { 
        bool runningCommand;
        int lastResult;
        R100DeviceControl DeviceControl { get{ if(deviceControl == null){ deviceControl = new R100DeviceControl(); deviceControl.OnUserDB += Control_OnUserDB; } return deviceControl; } }
        
        public List<String> GetIdentifications()
        {
            if(runningCommand) return null;
            DeviceControl.Open();
            runningCommand = true;
            lastResult = control.DownloadUserDB(out int count);
        }
        private void Control_OnUserDB(List<String> result)
        {
            runningCommand = false;
            // Get the list of string from here
        }
    }

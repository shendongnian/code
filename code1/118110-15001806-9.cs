    class FTP
    {
        public void Begin()
        {
            string filePath = DownloadFileFromFtpAndReturnPathName();
    
            SaveDatabase sd = new SaveDatabase();
            sd.Begin(filePath, NotifyFtpComplete());
        }
    
        private void NotifyFtpComplete()
        {
            //Code to send file to FTP site
        }
    }
    
   
    class SaveDatabase
    {
        private void Begin(string filePath, delegateType NotifyJobComplete())
        {
            SaveToTheDatabase(filePath);
            
            //InvokeTheDelegate - here we can execute the NotifyJobComplete method at our preferred moment in the application, despite the method being private and belonging to a different class. 
            NotifyJobComplete.Invoke();
        }
    }

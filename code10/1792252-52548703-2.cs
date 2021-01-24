    static object locker = new object();
    public void LogMessage(string Message)
    {
       lock (locker)
       {
             Entity objEntity = new Entity();                        
             objEntity.LogMessage = string.Format("\r\n{0:MM/dd/yyyy hh:mm:ss tt} : {1}", DateTime.Now, Message);
             objEntity.LogFilePath = ConfigurationManager.AppSettings.Get("ErrorLogPath");
             objEntity.LogFolderName = string.Format("{0:yyyy-MM}", DateTime.Now);
             objEntity.LogFilePath = objEntity.LogFilePath + objEntity.LogFolderName;
    
             if (!Directory.Exists(objEntity.LogFilePath))
             {
                 Directory.CreateDirectory(objEntity.LogFilePath);
             }
    
             using (StreamWriter sw = File.AppendText(objEntity.LogFilePath + "\\" + string.Format("{0:MM_dd_yyyy}", DateTime.Now) + ".txt"))
             {
                 sw.WriteLine(objEntity.LogMessage);
             }  
       }
    }

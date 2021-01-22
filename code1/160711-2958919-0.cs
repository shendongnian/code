    string LogFileDirectory = @"C:\Windows\Sysnative\winevt\Logs\";
    string LogFileExtension = ".evtx";
    string Date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
    string BackupDir = @"C:\Backups\" + Date + "\\";
    Directory.CreateDirectory(BackupDir);
    foreach (EventLog log in EventLog.GetEventLogs())
    {
     string source = LogFileDirectory + log.Log + LogFileExtension;
     string dest = BackupDir + log.Log + LogFileExtension;
     try
     {
      File.Copy(source, dest);
     }
     catch (Exception e)
     {
      Console.WriteLine("Error occured :" + e.Message);
      Console.WriteLine(e);
     }
     finally
     {
      if (!File.Exists(dest))
      {
       Console.WriteLine("Backup Failed for " + log.Log);
      }
      else
      {
       Console.WriteLine("Backup Successful for " + log.Log);
       //log.Clear();  // Commented out during development
      }
     }
    }

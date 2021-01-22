    namespace CustomLogging
    {
      public class SortByFolderFileAppender : log4net.Appender.RollingFileAppender
      {
        protected override void OpenFile(string fileName, bool append)
        {
          //Inject folder [yyyyMMdd] before the file name
          string baseDirectory = Path.GetDirectoryName(fileName);
          string fileNameOnly = Path.GetFileName(fileName);
          string newDirectory = Path.Combine(baseDirectory, DateTime.Now.ToString("yyyyMMdd"));
          string newFileName = Path.Combine(newDirectory, fileNameOnly);
    
          base.OpenFile(newFileName, append);
        }
      }
    }

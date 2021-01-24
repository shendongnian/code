    public interface ILogger {
        void log(string message);
        //...
    }
    
    public class Logger : ILogger {
        private readonly IPathProvider pathProvider;
        
        public Logger(IPathProvider pathProvider) {
            this.pathProvider = pathProvider;
        }
    
        public void log(string strLog) {
            FileStream fileStream = null;
            string username = Environment.UserName;
            string logFilePath = pathProvider.MapPath("~/log/Log.txt");
            var logFileInfo = new FileInfo(logFilePath);
            var logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            double fileSize = ConvertBytesToMegabytes(logFileInfo.Length);
            if (fileSize > 30) {
                string FileDate = DateTime.Now.ToString().Replace("/", "-").Replace(":", "-");
                string oldfilepath = pathProvider.MapPath("~/log/log-" + FileDate + ".txt");
                File.Move(logFileInfo.FullName, oldfilepath);
            }
            if (!logFileInfo.Exists) {
                fileStream = logFileInfo.Create();
            } else {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            using(fileStream) {
                using (var log = new StreamWriter(fileStream)) {
                    log.WriteLine(DateTime.Now.ToString("MM-dd HH:mm:ss") + " " + username + " " + strLog);
                    log.Close();
                }
            }
        }
    }
    

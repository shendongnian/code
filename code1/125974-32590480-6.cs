    public class FileVersionService
    {
        private IHostingEnvironment _hostingEnvironment;
        public FileVersionService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
    
        public string GetFileVersion(string filename)
        {
           var path = string.Format("{0}{1}", _hostingEnvironment.WebRootPath, filename);
           var fileInfo = new FileInfo(path);
           var version = fileInfo.LastWriteTimeUtc.ToString("yyyyMMddhhmmssfff");
           return version;
         }
    }

    public class FileDeleter
    {
        private readonly IFileOperator _fileOperator;
        public FileDeleter(IFileOperator fileOperator)
        {
            _fileOperator= fileOperator
        }
        public void Delete(string folder, int days)
        {
            var files = _fileClass.GetFiles(folder);
    
            foreach (var file in files)
            {
                var fi = _fileClass.GetFileInfo(file);
                var fiCreationTime = fi.CreationTime;
                var deleteOlderThan= DateTime.Now.AddDays(-days);
    
                if (fiCreationTime >= deleteOlderThan)
                    continue;
                fi.Delete();
            }
        }
    }
    public interface IFileClass 
    {
        IEnumerable<string> GetFiles(string path);
        IFileInfo GetFileInfo(string filePath);
    }
    public interface IFileInfo 
    {
        DateTime CreationTime { get; }
        void Delete();
    }

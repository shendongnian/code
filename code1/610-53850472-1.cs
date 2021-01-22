    public class FilePathHelper
    {
        private readonly IHostingEnvironment _env;
        public FilePathHelper(IHostingEnvironment env)
        {
            _env = env;
        }
        public string GetVirtualPath(string physicalPath)
        {
            if (physicalPath == null) throw new ArgumentException("physicalPath is null");
            if (!File.Exists(physicalPath)) throw new FileNotFoundException(physicalPath + " doesn't exists");
            var lastWord = _env.WebRootPath.Split("\\").Last();
            int relativePathIndex = physicalPath.IndexOf(lastWord) + lastWord.Length;
            var relativePath = physicalPath.Substring(relativePathIndex);
            return $"/{ relativePath.TrimStart('\\').Replace('\\', '/')}";
        }
        public string GetPhysicalPath(string relativepath)
        {
            if (relativepath == null) throw new ArgumentException("relativepath is null");
            var fileInfo = _env.WebRootFileProvider.GetFileInfo(relativepath);
            if (fileInfo.Exists) return fileInfo.PhysicalPath;
            else throw new FileNotFoundException("file doesn't exists");
        }

        public class FilePathHelper
    {
        private readonly IHostingEnvironment _env;
        public FilePathHelper(IHostingEnvironment env)
        {
            _env = env;
        }
        public string GetVirtualPath(string physicalPath)
        {
            var lastWord = _env.WebRootPath.Split("\\").Last();
            int relativePathIndex = physicalPath.IndexOf(lastWord) + lastWord.Length;
            var relativePath = physicalPath.Substring(relativePathIndex);
            return $"/{ relativePath.TrimStart('\\').Replace('\\', '/')}";
        }
        public string GetPhysicalPath(string relativepath)
        {
            var fileInfo = _env.WebRootFileProvider.GetFileInfo(relativepath);
            if (fileInfo.Exists) return fileInfo.PhysicalPath;
            else return null;
        }

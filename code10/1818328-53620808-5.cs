    public delegate string[] GetFilesFunction(string path);
    public class Download
    {
        private readonly IFoo _foo;
        private readonly GetFilesFunction _getFiles;
        public Download(IFoo foo, GetFilesFunction getFiles)
        {
            _foo = foo;
            _getFiles = getFiles;
        }
    ...

    public class Download
    {
        private readonly IFoo _foo;
        private readonly Microsoft.Extensions.FileProviders.IFileProvider _fileProvider;
        public Download(IFoo foo, IFileProvider fileProvider)
        {
            _foo = foo;
            _fileProvider = fileProvider;
        }
        public void SomethingWithFiles()
        {
            var files = _fileProvider.GetDirectoryContents("filepath")
                .Where(item => !item.IsDirectory);
            foreach (var item in files)
            {
                // something
            }
        }
    }

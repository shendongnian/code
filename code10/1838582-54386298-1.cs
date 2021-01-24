    public class ApplicationData : IApplicationData
    {
        readonly IHostingEnvironment _hostingEnvironment;
        public ApplicationData(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string RootFolderName => "Upload";
        public string ProductPictureFolder => "ProductPictureFolder";
        public string ProductMainPictureFolder => "ProductMainPicture";
        public string WebRootPath => _hostingEnvironment.WebRootPath;
        public string RootPath => Path.Combine(WebRootPath, RootFolderName);
        public string GetProductPicturePath()
        {
            return Path.Combine(WebRootPath, RootFolderName, ProductPictureFolder);
        }
        public string GetProductMainPicturePath()
        {
            string path = Path.Combine(WebRootPath, RootFolderName, ProductPictureFolder, ProductMainPictureFolder);
            return path;
        }
        public string GetNewPath()
        {
            string productMainPicturePath = GetProductMainPicturePath();
            return Path.Combine(WebRootPath, productMainPicturePath);
        }
    }

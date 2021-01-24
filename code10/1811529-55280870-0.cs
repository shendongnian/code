    public AngularController: Controller
    {
        private IAppSettings appSettings;
        public AngularController(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        public IActionResult Index()
        {
            var fileProvider = new EmbeddedFileProvider(this.appSettings.WebAssembly, this.appSettings.WebNamespace);
            var contents = this.fileProvider.GetDirectoryContents(string.Empty);
            IFileInfo index = null;
            foreach (var file in contents)
            {
                if (file.Name.Equals("index.html"))
                {
                    index = file;
                    break;
                }
            }
            if (index == null)
            {
                throw new Exception("'index.html' not found");
            }
            var reader = new StreamReader(index.CreateReadStream());
            var text = reader.ReadToEnd();
            return this.Content(text, "text/html");
        }
    }

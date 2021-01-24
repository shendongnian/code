        public IList<string> StandardAssemblyReferences { get; set; } = new string[]
        {
            typeof(System.Uri).Assembly.Location,
            "System.IO.FileSystem.dll",
        };
        public IList<string> StandardImports { get; set; } = new List<string>
        {
            "System",
        };

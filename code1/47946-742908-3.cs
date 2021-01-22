    // Use a class variable so that the RNG is only created once.
    private Random generator;
    private Random Generator
    {
        get
        {
            if (this.generator == null)
            {
               this.generator = new Random();
            }
            return this.generator;
        }
    }
    private string getrandomfile(string path)
    {
        string file = null;
        if (!string.IsNullOrEmpty(path))
        {
            var extensions = new string[] { ".png", ".jpg", ".gif" };
            try
            {
                var di = new DirectoryInfo(path);
                var rgFiles = di.GetFiles("*.*")
                                .Where( f => extensions.Contains( f.Extension
                                                                   .ToLower() );
                int fileCount = rgFiles.Count();
                if (fileCount > 0)
                {
                    int x = this.Generator.Next( 0, fileCount );
                    file = rgFiles.ElementAt(x).FullName;
                }
            }
            // probably should only catch specific exceptions
            // throwable by the above methods.
            catch {}
        }
        return file;
    }

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
                    Random r = new Random();
                    int x = r.Next( 0, fileCount );
                    file = rgFiles.ElementAt(x).FullName;
                }
            }
            // probably should only catch specific exceptions
            // throwable by the above methods.
            catch {}
            return file;
        }

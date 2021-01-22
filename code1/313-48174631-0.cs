    public async Task<string> CreateZipFile(string sourceDirectoryPath, string name)
        {
            var path = HostingEnvironment.MapPath(TempPath) + name;
            await Task.Run(() =>
            {
                if (File.Exists(path)) File.Delete(path);
                ZipFile.CreateFromDirectory(sourceDirectoryPath, path);
            });
            return path;
        }

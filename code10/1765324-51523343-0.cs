        var files = new List<IFileInfo>();
        GetFiles("C:/Tests", files);
        private void GetFiles(string path, ICollection<IFileInfo> files)
        {
            IFileProvider provider = new PhysicalFileProvider(path);
            var contents = provider.GetDirectoryContents("");
            foreach (var content in contents)
            {
                if (!content.IsDirectory && content.Name.ToLower().EndsWith(".pdf"))
                {
                    files.Add(content);
                }
                else
                {
                    GetFiles(content.PhysicalPath, files);
                }
            }
        }

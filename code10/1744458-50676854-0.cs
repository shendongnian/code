    public async void DirSearch(string sDir)
    {
        var ext = new List<string> { ".rar", ".zip" };
        var folder = await StorageFolder.GetFolderFromPathAsync(sDir);
        var exactFile = await folder.CreateFileAsync("newFile", CreationCollisionOption.GenerateUniqueName);
        using (var writeStream = await exactFile.OpenStreamForWriteAsync())
        {
            foreach (var file in await folder.GetFilesAsync())
            {
                if (ext.Contains(file.FileType))
                {
                    var stream = await file.OpenReadAsync();
                    var archive = ArchiveFactory.Open(stream.AsStream());
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            Console.WriteLine(entry.Key);
                            entry.WriteTo(writeStream);
                        }
                    }
                    Debug.WriteLine(file);
                }
            }
        }
    }

    public async void DirSearch(string sDir)
    {
        var ext = new List<string> { ".rar", ".zip" };
        var folder = await StorageFolder.GetFolderFromPathAsync(sDir);
        var ExactLocalFolder =await ApplicationData.Current.LocalFolder.CreateFolderAsync("ExactLocalFolder");
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
                        //extract the files to local folder
                        entry.WriteToDirectory(ExactLocalFolder.Path);
                    }
                }
            }
        }
        //copy the files to the folder that you want to save the extract file into
        foreach (var file in await ExactLocalFolder.GetFilesAsync())
        {
            await file.CopyAsync(folder);
        }
        //delete the folder in the local folder
        await ExactLocalFolder.DeleteAsync();
    }

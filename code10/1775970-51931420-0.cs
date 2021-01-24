    using System.IO.Compression;
            
    var files = System.IO.Directory.EnumerateFiles(string PATH, ".jpeg", System.IO.SearchOption.AllDirectories)
                
                foreach (var file in files)
                                {
                                File.Copy(file, tempPath + @"\" + System.IO.Path.GetFileName(file));
                                }
                
        ZipFile.CreateFromDirectory(tempPath, zipPath, CompressionLevel.Fastest, true);
        
        Directory.Delete(tempPath, true); //delete tempfolder

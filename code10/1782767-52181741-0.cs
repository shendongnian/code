    public override string[] CreateEmptyFiles()
    {
        var fileTypeFormat = "*." + FileType;
        var filesToCopy = Directory.GetFiles(RootDirectory, fileTypeFormat);
        foreach (var file in filesToCopy)
        {
            var directoryHierarchy = file.Split('\\');
            var fileName = directoryHierarchy[directoryHierarchy.Length - 1];
            var newFileDestination = destinationFolder + "\\" + fileName;
            //Copy File over
            File.Copy(file,newFileDestination);
            File.Delete(file);
        }
        return new string[10];
    }

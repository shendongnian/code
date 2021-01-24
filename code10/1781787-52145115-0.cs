    foreach (string path in pdfFiles)
    {
        file = Path.GetFileName(path);
        subString = file.Substring(0, 8);
        var targetFolder = Path.Combine(targetPath, subString);
        Directory.CreateDirectory(targetFolder);
        // Move the file into the created folder
        File.Move(path, Path.Combine(targetFolder, file));
    } 

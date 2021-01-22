    public void Rename(string filePath, string newFileName)
    {
    	var newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName + Path.GetExtension(filePath));
    	System.IO.File.Move(filePath, newFilePath);
    }

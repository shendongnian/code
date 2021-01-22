    public static FileInfo GetNextUniqueFile(string path)
    {
        //if the given file doesn't exist, we're done
        if(!File.Exists(path))
            return new FileInfo(path);
        //split the path into parts
        string dirName = Path.GetDirectoryName(path);
        string fileName = Path.GetFileNameWithoutExtension(path);
        string fileExt = Path.GetExtension(path);
        //get the directory
        DirectoryInfo dir = new DirectoryInfo(dir);
        //get the list of existing files for this name and extension
        var existingFiles = dir.GetFiles(Path.ChangeExtension(fileName + " *", fileExt);
        //get the number strings from the existing files
        var NumberStrings = from file in existingFiles
                            select Path.ChangeExtension(file.Name, null)
                                .Remove(0, fileName.Length /*we remove the space too*/);
        //find the highest existing number
        int highestNumber = 0;
        foreach(var numberString in NumberStrings)
        {
            int tempNum;
            if(Int32.TryParse(numberString, out tempnum) && tempNum > highestNumber)
                highestNumber = tempNum;
        }
        
        //make the new FileInfo object
        string newFileName = fileName + " " + (highestNumber + 1).ToString();
        newFileName = Path.ChangeExtension(fileName, fileExt);
        return new FileInfo(Path.Combine(dirName, newFileName));
    }

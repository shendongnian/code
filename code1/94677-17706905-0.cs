    public string GetUniqueName(string name, string folderPath)
    {
        string pathAndFileName = Path.Combine(folderPath, name);
        string validatedName = name;
        int count = 1;
        while(File.Exists(Path.Combine(folderPath, validatedName)))
        {
            validatedName = string.Format("{0}{1}{2}",
                Path.GetFileNameWithoutExtension(pathAndFileName),
                count++,
                Path.GetExtension(pathAndFileName));
        }
        return validatedName;
    }

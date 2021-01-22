    private string GetUniqueName(string name, string folderPath)
    {
        string validatedName = name;
        int tries = 1;
        while (File.Exists(folderPath + validatedName))
        {
            validatedName = string.Format("{0} [{1}]", name, tries++);
        }
        return validatedName;
    }

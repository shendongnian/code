    string GetNewTempFile(string extension)
    {
        if (!extension.StartWith(".")) extension="." + extension;
        string fileName;
        bool bCollisions = false;
        do {
            fileName = Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + extension);
            try
            {
                using (new FileStream(fileName, FileMode.CreateNew)) { }
                bCollisions = false;
            }
            catch (IOException)
            {
                bCollisions = true;
            }
        }
        while (bCollisions);
        return fileName;
    }

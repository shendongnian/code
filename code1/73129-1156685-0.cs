    using (FileStream fs = new FileStream(FilePath, FileMode.Open))
    {
        // Another small optimization, removed unnecessary variable 
        byte[] iba = new byte[(int)fs.Length];
        fs.Read(iba, 0, iba.Length);
    }

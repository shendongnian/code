    private bool FileHashesAreEqual(FileInfo fileName)
    {
        byte[] firstHash = MD5.Create().ComputeHash(fileName.OpenRead());
    
        if (!this.fileHashDictionary.ContainsKey(fileName.Name))
        {
            this.fileHashDictionary.Add(fileName.Name, firstHash.ToString());
        }
        else
        {
            if (this.fileHashDictionary.TryGetValue(fileName.Name, out var value))
            {
                if (value != null)
                {
                   for (var index = 0; index < value.Length; index++)
                   {
                       if (value[index] != firstHash[index])
                       {
                           return false;
                       }
                    }
                 }
             }
        }
    
        return true;
    }

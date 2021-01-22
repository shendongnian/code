    public Dictionary<string,string> GetChecksums(string[] filePaths)
    { 
        var checksums = new Dictionary<string,string>(filePaths.length);
    
        using (SHA1Managed sha1 = new SHA1Managed()) 
        { 
             foreach (string filePath in filePaths) {
                  using (var fs = File.OpenRead(filePath)) {
                      checksums.Add(filePath, BitConverter.ToString(sha1.ComputeHash(fs)));
                  }
             }         
        }
        return checksums;
    }

    private string ChecksumFolder(string path, out List<string> inaccessibleFiles)
    {
        inaccessibleFiles = null;
        FindFiles(path, "*", true, out List<string> accessible, out List<string> inaccessible);
        inaccessibleFiles = inaccessible;
    
        StringBuilder allChecksum = new StringBuilder();
    
        for (int count = 0; count < accessible.Count; count++)
        {
            allChecksum.Append(CreateChecksumFromFile(accessible[count]));
        }
    
        return CreateChecksumFromString(allChecksum.ToString());
    }

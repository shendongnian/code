    string dirPath = @"M:\Folder Directory";
    string filePattern = "*.pdf";
    DirectoryInfo di = new DirectoryInfo(dirPath);
    FileInfo[] files = di.GetFiles(filePattern, SearchOption.AllDirectories);
    Dictionary<string, FileInfo> matchedFiles = new Dictionary<string, FileInfo>();
    foreach (FileInfo file in files)
    {
        string filename = file.Name;
        string[] seperatedFilename = filename.Split('-');
        // We are assuming that filenames are consistent
        // As such,
        // the value at seperatedFilename[1] will always be Series No
        // the value at seperatedFilename[2] will always be Revision
        // If this is not the case in every scenario, the following code should expanded to allow other cases
        string seriesNo = seperatedFilename[1];
        string revision = seperatedFilename[2];
        if (matchedFiles.ContainsKey(seriesNo))
        {
            FileInfo matchedFile = matchedFiles[seriesNo];
            string matchedRevision = matchedFile.Name.Split('-')[2];
            // Compare on the char values - https://docs.microsoft.com/en-us/dotnet/api/system.string.compareordinal?view=netframework-4.7.2
            // If the value is int, then it can be cast to integer for comparison
            if (String.CompareOrdinal(matchedRevision, seriesNo) > 0)
            {
                // This file is higher than the previous
                matchedFiles[seriesNo] = file;
            }
        } else
        {
            // Record does not exist - so its is added by default
            matchedFiles.Add(seriesNo, file);
        }
    }
    // We have a list of all files which match our criteria
    foreach (FileInfo file in matchedFiles.Values)
    {
        // TODO : Determine if the directory path is also required for the file
        Console.WriteLine(file.FullName);
    }

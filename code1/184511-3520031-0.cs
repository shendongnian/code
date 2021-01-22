    public void recursiveMethod(SPFolder sourceFolder, SPFolder destinationFolder)
    {
        int folderIndex = 1;
        recursiveMethod(sourceFolder, destinationFolder, ref folderIndex);
    }
    public void recursiveMethod(SPFolder sourceFolder, SPFolder destinationFolder, ref folderIndex)
    {
        int totalNumberOfFiles = sourceFolder.SubFolders.Count;
    
        foreach (SPFolder sourceSubFolder in sourceFolder.SubFolders)
        {
            // Display processed folder
            Console.WriteLine("Processing folder " + folderIndex);
            if (true)
            {
                SPFolder destSubFolder = null;
                if (true)
                {
                    destSubFolder = doSomething();
                }
                else
                {
                    destSubFolder = doSomethingElse();
                }
            }
            // Increase processed folder index
            folderIndex++;
            // Recursive call
            recursiveMethod(sourceSubFolder, destSubFolder, ref folderIndex);
        }
    }

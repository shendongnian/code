    FileOverwriteMode overwriteMode = FileOverwriteMode.DateAndSize;
    if (new HashSet<FileOverwriteMode> 
        { 
            FileOverwriteMode.DateAndSize, 
            FileOverwriteMode.DateOrSize, 
            FileOverwriteMode.Date, 
            FileOverwriteMode.Size 
        }.Contains(overwriteMode))
    {
    }

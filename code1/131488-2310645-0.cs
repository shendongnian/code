    private static readonly ValidOverwriteModes = new HashSet<FileOverWriteMode>
    {
        FileOverwriteMode.DateAndSize, FileOverwriteMode.DateOrSize,
        FileOverwriteMode.Date, FileOverwriteMode.Size,
    };
    ...
    if (ValidOverwriteModes.Contains(overwriteMode))
    {
        // ...
    }

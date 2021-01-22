    private static readonly HashSet<FileOverWriteMode> ValidOverwriteModes
        = new HashSet<FileOverWriteMode>
    {
        FileOverwriteMode.DateAndSize, FileOverwriteMode.DateOrSize,
        FileOverwriteMode.Date, FileOverwriteMode.Size,
    };
    ...
    if (ValidOverwriteModes.Contains(overwriteMode))
    {
        // ...
    }

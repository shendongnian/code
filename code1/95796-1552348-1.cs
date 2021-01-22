    public static TransferFileList ToTransferFileList(
        this IEnumerable<TransferFile> files)
    {
        return new TransferFileList(files);
    }
    // ...
    var files = uploadResponse.Files.Where(x => !x.Success).ToTransferFileList(); 

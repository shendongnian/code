    [NonAction]
    public virtual PhysicalFileResult PhysicalFile(
        string physicalPath,
        string contentType,
        string fileDownloadName)
        => new PhysicalFileResult(physicalPath, contentType) { FileDownloadName = fileDownloadName };

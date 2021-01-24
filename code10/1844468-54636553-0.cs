    if (blob is CloudBlockBlob)
    {
        var cloudBlockBlob = (CloudBlockBlob) blob;
        var blobFileName = cloudBlockBlob.Uri.Segments.Last().Replace("%20", " ");
        var blobFilePath = cloudBlockBlob.Uri.AbsolutePath.Replace(cloudBlockBlob.Container.Uri.AbsolutePath + "/", "").Replace("%20", " ");
        var blobPath = blobFilePath.Replace("/" + blobFileName, "");
        var blobLM = cloudBlockBlob.Properties.LastModified; // this is where I cannot access the LastModified poperty
        blobInfos.Add(new BlobFileInfo
        {
            FileName = blobFileName,
            BlobPath = blobPath,
            BlobFilePath = blobFilePath,
            Blob = cloudBlockBlob,
            LastModified = blobLM
        });
    }

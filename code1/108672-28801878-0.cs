    // Make the upload request with the required cache and header parameters
    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
    {
       BucketName = BucketName,
       FilePath = fileName,
       StorageClass = S3StorageClass.Standard,
       Key = keyName,
       CannedACL = S3CannedACL.PublicRead,
       ContentType = contentType,
    };
    
    fileTransferUtilityRequest.Headers.CacheControl = "max-age=604800";
    var fileTransferUtility = new TransferUtility(...);
    fileTransferUtility.Upload(fileTransferUtilityRequest);

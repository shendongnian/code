    try
        {
            TransferUtilityUploadDirectoryRequest request = new TransferUtilityUploadDirectoryRequest
            {
                BucketName = bucket,
                Directory = uploadDirectory,
                SearchOption = System.IO.SearchOption.AllDirectories,
                CannedACL = S3CannedACL.PublicRead
            };
            _transferUtility.UploadDirectory(request);
            return true;
        }
        catch (Exception exception)
        {
            //Log Exception
            return false;
        }

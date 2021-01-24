    UploadResult<DriveItem> uploadResult = null;
    try
    {
        uploadResult = await largeFileUploadTask.UploadAsync(progress);
                        
        if (uploadResult.UploadSucceeded)
        {
            Console.WriteLine($"File Uploaded {uploadResult.ItemResponse.Id}");//Sucessful Upload
        }
    }
    catch (ServiceException e)
    {
        Console.WriteLine(e.Message);
    }

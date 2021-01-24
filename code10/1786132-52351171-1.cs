    public async Task BackupFile(byte[] file)
    {
        try
        {
            await BackUpToAmazonS3(file);
        }
        catch (AmazonS3LoadingException)
        {
            await BackUpToLocalDisk(file);
        }
    }

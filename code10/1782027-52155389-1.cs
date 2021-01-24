    private static CloudStorageAccount storageAccount;
    static void Main(string[] args)
    {
        try
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        }
        catch (Exception)
        {                
            throw;
        }
    }

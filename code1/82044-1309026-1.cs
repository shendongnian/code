    delegate void ProcessDelegate<T>(T param);
    .
    .
    public static void Process(ProcessDelegate processDelegate)
    {
        using (var esb = ExchangeService.GetExchangeServiceBinding())
        {
            var contactFolder = FolderService.GetPublicFolder(esb,  
                Properties.Settings.Default.ExchangePublicFolderName);
            processDelegate(contactFolder);
        }
    }

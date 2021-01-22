    public static void ProcessFolder(ProcessFolderDelegate del)
    {
        Process((b, f) => del(b, f));
    }
    public static void ProcessContact(ProcessContactDelegate del, Contact contact)
    {
        Process((b, f) => del(b, f, contact));
    }
    private static void Process(
        Action<ExchangeServiceBinding, ContactsFolderType> action)
    {
        // i've guessed that esb is of type ExchangeServiceBinding
        // and that contactFolder is of type ContactsFolderType
        // if that's not the case then change the type parameters
        // of the Action delegate in the method signature above
        using (var esb = ExchangeService.GetExchangeServiceBinding())
        {
            var contactFolder = FolderService.GetPublicFolder(
                esb, Properties.Settings.Default.ExchangePublicFolderName);
            action(esb, contactFolder);
        }
    }

    private static void ConnectToExchangeService()
    {
        service = new ExchangeService(); 
        service.Credentials = new WebCredentials(USERNAME, PASSWORD, DOMAIN_NAME);
        service.AutodiscoverUrl(USER_ADDRESS);
    }
    
    private static void ListGlobalContacts(ExchangeService service)
    {
        /* passing true as the third parameter to "ResolveName" is important to
           make sure you get the contact details as well as the mailbox details */
        NameResolutionCollection searchResult = service.ResolveName(NAME_YOURE_LOOKING_FOR, ResolveNameSearchLocation.DirectoryOnly, true);
        foreach (NameResolution resolution in searchResult )
        {
            Console.WriteLine("name is " + resolution.Contact.DisplayName);
            Console.WriteLine("address is " + resolution.Mailbox.Address);
            Console.WriteLine("business phone is " + resolution.Contact.PhoneNumbers[PhoneNumberKey.BusinessPhone]);
            Console.WriteLine("mobile phone is " + resolution.Contact.PhoneNumbers[PhoneNumberKey.MobilePhone]);
        }
    }

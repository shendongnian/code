    public IMessageProvider LocateProviderByName(string providerName)
    {
        return IoC.Resolve<IMessageProvider>(providerName);
    }
    
    var messageProvider = LocateProviderByName("smtpProvider");

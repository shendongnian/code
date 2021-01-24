    var exchangeVersion = ExchangeVersion.Exchange2010_SP2; // or any valid version
    ExchangeService myService = new ExchangeService(exchangeVersion)
    {
       Credentials = new WebCredentials(username, password),
       Url = new Uri(exchangeUrl)
    };

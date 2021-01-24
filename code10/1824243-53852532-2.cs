    public static class ConnectionToEws
        {
            private static bool RedirectionUrlValidationCallback(string redirectionUrl)
            {
                bool result = false;
                var redirectionUri = new Uri(redirectionUrl);
                if (redirectionUri.Scheme == "https")
                {
                    result = true;
                }
                return result;
            }
    
            public static ExchangeService ConnectToService()
            {
                var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2)
                {
                    Credentials = new WebCredentials("Login", "Password")
                    ,UseDefaultCredentials = false
                };
                service.AutodiscoverUrl("EmailAddress", RedirectionUrlValidationCallback);
                return service;
            }
        }

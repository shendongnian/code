        string exchangeServer;
        public void SendMail(string recipient, string subject, string body)
        {
            var service = CreateService(recipient);      
            EmailMessage message = new EmailMessage(service);
            message.Subject = subject;
            message.Body = body;
            message.ToRecipients.Add(recipient);
            message.SendAndSaveCopy();
        }
        private ExchangeService CreateService(string recipient)
        {
            var service = new ExchangeService(ExchangeVersion.Exchange2010);
            service.Url = new Uri(exchangeServer);
            service.Credentials = new WebCredentials(Credential.impersonateUser, Credential.impersonatePassword);
            service.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, recipient);
            service.HttpHeaders.Add("X-AnchorMailbox", recipient);
            return service;
        }

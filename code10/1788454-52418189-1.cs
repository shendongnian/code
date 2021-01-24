    public async Task<bool> SendAsync(EmailAddress toaddress)
        {
            var email = new Message
            {
                Body = new ItemBody
                {
                    Content = "Test for sending eamil ",
                    ContentType = BodyType.Text,
                },
                Subject = "Test for sending eamil",
                ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                       EmailAddress = toaddress 
                    }
                },
            };
            try
            {
                await _serviceClient.Me.SendMail(email).Request().PostAsync(); // the _serviceClient is the result in the step1.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

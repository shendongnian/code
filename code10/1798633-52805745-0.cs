    private async Task configSendGridasync(IdentityMessage message)
        {
            var apiKey = Convert.ToString(ConfigurationManager.AppSettings["SendGridApiKey"]);
            var client = new SendGridClient(apiKey);
            var myMessage = new SendGridMessage();
            myMessage.AddTo(new EmailAddress(message.Destination));
            myMessage.SetFrom(new EmailAddress("Joe@contoso.com", "Joe S."));
            myMessage.SetSubject(message.Subject);
            myMessage.AddContent(MimeType.Text, message.Body);
            myMessage.AddContent(MimeType.Html, message.Body);
              try
               {
                  var response = await client.SendEmailAsync(msg);
               }
               catch(Exception err)
               {
                Trace.TraceError("Failed to create Web transport: ."+err.message);
                await Task.FromResult(0);
              }  
        }

    MailjetClient client = new MailjetClient("MJ_APIKEY_PUBLIC", "MJ_APIKEY_PRIVATE");
             MailjetRequest request = new MailjetRequest
             {
                Resource = Send.Resource,
             }
                .Property(Send.FromEmail, "pilot@mailjet.com")
                .Property(Send.FromName, "Mailjet Pilot")
                .Property(Send.Subject, "Your email flight plan!")
                .Property(Send.TextPart, "Dear passenger, welcome to Mailjet!")
                .Property(Send.HtmlPart, "<h3>Dear passenger, welcome to Mailjet!</h3>")
                .Property(Send.Recipients, new JArray {
                    new JObject {
                     {"Email", "passenger@mailjet.com"}
                     }
                    })
                .Property(Send.Headers, new JObject {
                    {"Reply-To", "copilot@mailjet.com"}
                    });
             MailjetResponse response = await client.PostAsync(request);
    

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("test@example.com", "Example User"));
            msg.AddTo(new EmailAddress("test@example.com", "Example User"));
            msg.SetTemplateId("d-d42b0eea09964d1ab957c18986c01828");
            var dynamicTemplateData = new ExampleTemplateData
            {
                Subject = "Hi!",
                Name = "Example User"
            };
            msg.SetTemplateData(dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);
        private class ExampleTemplateData
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }
            
            [JsonProperty("name")]
            public string Name { get; set; }
        }

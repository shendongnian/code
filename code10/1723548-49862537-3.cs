    static void Main(string[] args)
    {
        using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1)) 
        {
            var sendRequest = new SendEmailRequest
            {
                Source = senderAddress,
                Destination = new Destination
                {
                    ToAddresses =
                    new List<string> { receiverAddress }
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = htmlBody
                        },
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = textBody
                        }
                    }
                },
                ConfigurationSetName = configSet
            };
            try
            {
                Console.WriteLine("Sending email using Amazon SES...");
                var response = client.SendEmailAsync(sendRequest).GetAwaiter().GetResult();
                Console.WriteLine("The email was sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The email was not sent.");
                Console.WriteLine("Error message: " + ex.Message);
            }
        }
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

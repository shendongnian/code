    MailjetClient client = new MailjetClient(ConfigurationManager.AppSettings["apiKey"], ConfigurationManager.AppSettings["apiSecret"]);
    
                MailjetRequest request = new MailjetRequest()
                {
                    Resource = Contact.Resource,
                }
                .Property(Contact.Email, "Mister@mailjet.com");
    
                MailjetResponse response = await client.PostAsync(request);
    
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
    
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                    Console.WriteLine(response.GetData());
                }
                else
                {
                    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
                }

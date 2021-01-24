    [HttpPost]    
    public async Task Email(ServiceRequest servicerequest)
    {
        try
        {
            string from = "youremailadress@gmail.com"
            string to = servicerequest.serviceRequestEmail;
            string subject = servicerequest.serviceType;
            //it's up to you what you want to put in the body
            string body = String.Format("city:{0}\n\nComments:{1}\n\n
            PhoneNumber\n\n",serviceRequest.serviceRequestCity, 
            serviceRequest.serviceRequestComments, serviceRequest.serviceRequestNumber);
            string email = System.Configuration.ConfigurationManager.AppSettings["email"];
            string password = 
                System.Configuration.ConfigurationManager.AppSettings["emailpassword"];
            string server = 
                System.Configuration.ConfigurationManager.AppSettings["emailserver"];
            string emailport = 
                System.Configuration.ConfigurationManager.AppSettings["emailport"];
            int port = Int32.Parse(emailport);
            var client = new SmtpClient(server, port)
            {
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            };
            await client.SendMailAsync("from", to, subject, body);
            Console.WriteLine("Sent");
        }
        catch (Exception e)
        {
           Console.WriteLine(String.Format("Error occured at {0}. Full stack trace of error {1}", System.DateTime.Now.ToString(),e.ToString()));
        }
    }

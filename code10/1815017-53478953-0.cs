    #r "SendGrid"
    
    using System.Text.RegularExpressions;
    using SendGrid.Helpers.Mail;
               
    public static void Run(string myBlob, string filename, ILogger log, out SendGridMessage message)
    {  
        var email = Regex.Match(myBlob, @"^email\:\ (.+)$", RegexOptions.Multiline).Groups[1].Value;
        log.LogInformation($"Got order from {email}\n License File Name: {filename} ");
       
        message = new SendGridMessage();
        message.AddTo(new EmailAddress(email));
        var base64Content = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(myBlob));
    
        message.AddAttachment(
            "license.lic",
            base64Content,
            "text/plain",
            "attachment",
            "License File"
        );
    
        message.AddContent("text/html", "Your license file attached");
        message.Subject = "Thanks for your order";
        message.From = new EmailAddress("test3@test.com");
    }

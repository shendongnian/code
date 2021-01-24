    #r "SendGrid"
    
    using System;
    using System.Net;
    using SendGrid.Helpers.Mail;
    
    public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log, ICollector<Mail> mails)
    {
        log.Info("C# HTTP trigger function processed a request.");
    
        Mail message = new Mail()
        {
            Subject = $"Hello world from the SendGrid C#!"
        };
    
        var personalization = new Personalization();
        personalization.AddTo(new Email("foo@bar.com"));  
        personalization.AddTo(new Email("foo2@bar.com")); 
        // you can add some more recipients here 
    
        Content content = new Content
        {
            Type = "text/plain",
            Value = $"Hello world!"
        };
    
        message.AddContent(content);  
        message.AddPersonalization(personalization); 
        mails.Add(message);
    
        return null;
    }

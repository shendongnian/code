    using System;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    
    
    class Program 
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "ACc0966dd96e4d55d26ae72df4d6dc3494";
            const string authToken = "your_auth_token";
    
    
            TwilioClient.Init(accountSid, authToken);
    
            var incomingPhoneNumbers = IncomingPhoneNumberResource.Read();
    
            foreach(var record in incomingPhoneNumbers)
            {
               Console.WriteLine(record.PhoneNumber);
            }
        }
    }

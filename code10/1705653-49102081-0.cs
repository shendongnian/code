    using System;
    using System.Collections.Generic;
    using Twilio;
    using Twilio.Rest.Notify.V1.Service;
    
    public class Example
    {
        public static void Main(string[] args)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            const string accountSid = "your_account_sid";
            const string authToken = "your_auth_token";
            const string serviceSid = "your_messaging_service_sid";
    
            TwilioClient.Init(accountSid, authToken);
    
            var notification = NotificationResource.Create(
                serviceSid,
                toBinding: new List<string> { "{\"binding_type\":\"sms\",\"address\":\"+15555555555\"}",
                "{\"binding_type\":\"sms\",\"address\":\"+123456789123\"}" },
                body: "Hello Bob");
    
            Console.WriteLine(notification.Sid);
        }
    }

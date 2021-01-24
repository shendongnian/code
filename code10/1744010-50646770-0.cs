    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Twilio;
    using Twilio.AspNet.Mvc;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;
    
    namespace TwilioSendSMS.Controllers
    {
        public class SMSController : TwilioController
        {
            // GET: SMS ----- outbound----
            public ActionResult SendSms()
            {
    
                // Find your Account Sid and Auth Token at twilio.com/user/account
                const string accountSid = "ACxxxxxxxxx";
                const string authToken = "71xxxxxxxxxx";
    
                // Initialize the Twilio client
                TwilioClient.Init(accountSid, authToken);
    
                // make an associative array of people we know, indexed by phone number
                var people = new Dictionary<string, string>() {
                    {"+18180000000", "Kim"},
                    {"+14401112222", "Raj"}
                };
    
                // Iterate over all our friends
                var name ="";
                foreach (var person in people)
                {
                    // Send a new outgoing SMS by POSTing to the Messages resource
                    MessageResource.Create(
                        from: new PhoneNumber("+15005550006"), // From number, must be an SMS-enabled Twilio number
                        to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
                                                         // Message content
                        body: $"Hey {person.Value} Party is at 6PM! Don't forget to bring gift.");
                  name = $"{name} {person.Value}";
    
    
                }
                
                return Content($"Sent message to {name}");
    
            }
        }
    }

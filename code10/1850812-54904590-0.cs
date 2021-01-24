     using DocGen.Notifications.Contract;
            using DocGen.Notifications.Models;
            using System;
            using System.Configuration;
            using System.Linq;
            using System.Text;
            using Twilio;
            using Twilio.Rest.Api.V2010.Account;
            using Twilio.Types;
            
            namespace DocGen.Notifications.Providers
            {
                public class SmsNotificationProvider : INotificationProtocolContract
                {
                    NotificationResponseModel notificationResponseModel = new NotificationResponseModel();
                    public NotificationResponseModel SendNotification(NotificationRequestModel notificationRequestModel)
                    {
                        if (notificationRequestModel.SmsTo == null || notificationRequestModel.SmsTo.Count() == 0)
                            throw new ArgumentNullException(nameof(notificationRequestModel.SmsTo));
        
                        TwilioClient.Init(ConfigurationManager.AppSettings["accountSid"], ConfigurationManager.AppSettings["authToken"]);
            
                        foreach (var Sms_to in notificationRequestModel.SmsTo)
                        {
                            var to = new PhoneNumber(Sms_to);
                            var message = MessageResource.Create(
                                to,
                                from: new PhoneNumber(ConfigurationManager.AppSettings["senderNumber"]),//"+12563054795"
                                body: Encoding.UTF8.GetString(notificationRequestModel.Message));
            
                            notificationResponseModel.ResponseMessage = message.Status.ToString();
                        }
            
                        //notificationResponseModel.ResponseMessage = "Message Successfully sent.";
            
                        return notificationResponseModel;
                    }
                }
            }
            
                

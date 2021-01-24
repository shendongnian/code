    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using SendGrid.Helpers.Mail;
    
    namespace ScheduledMail
    {   
        public static class FifteenMinMail
        {
            [FunctionName("FifteenMinMail")]
            public static void Run([TimerTrigger("0 */15 * * * *")]TimerInfo myTimer, [SendGrid(ApiKey = "AzureWebJobsSendGridApiKey")] out SendGridMessage message, TraceWriter log)
            {
                log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
                message = new SendGridMessage();
                message.AddTo("BLABLABLA @gmail or @outlook etc here.");
                message.AddContent("text/html", "This mail will repeat every 15 minutes.");
                message.SetFrom(new EmailAddress("BLABLABLA @gmail or @outlook etc here."));
                message.SetSubject("TEST Mail");
            }
        }
    }

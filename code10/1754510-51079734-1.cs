    public static void Run([TimerTrigger("0 */15 * * * *")]TimerInfo myTimer, [SendGrid(ApiKey = "sendgridkey")] out SendGridMessage message, TraceWriter log)
            {
                log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
                message = new SendGridMessage();
                message.AddTo("testto@gmail.com");
                message.AddContent("text/html", "Test body");
                message.SetFrom(new EmailAddress("testfrom@gmail.com"));
                message.SetSubject("Subject");
    
            }

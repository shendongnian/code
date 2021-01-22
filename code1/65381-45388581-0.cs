      public ActionResult ios()
        {
            string message = string.Empty;
            var certi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates2.p12");
            var appleCert = System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates2.p12"));
            ApnsConfiguration apnsConfig = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, appleCert, "Password");
            var apnsBroker = new ApnsServiceBroker(apnsConfig);
            apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {
                aggregateEx.Handle(ex =>
                {
                    if (ex is ApnsNotificationException)
                    {
                        var notificationException = (ApnsNotificationException)ex;
                        var apnsNotification = notificationException.Notification;
                        var statusCode = notificationException.ErrorStatusCode;
                        var inner = notificationException.InnerException;
                        message = "IOS Push Notifications: Apple Notification Failed: ID=" + apnsNotification.Identifier + ", Code=" + statusCode + ", Inner Exception" + inner;
                    }
                    else
                    {
                        message = "IOS Push Notifications: Apple Notification Failed for some unknown reason : " + ex.InnerException;
                    }
                    return true;
                });
            };
            apnsBroker.OnNotificationSucceeded += (notification) =>
            {
                message = "IOS Push Notifications: Apple Notification Sent!";
            };
            apnsBroker.Start();
            try
            {
                string deviceToken = "33c2f3a13c90dc62660281913377c22066c1567e23c2ee2c728e0f936ff3ee9b";
                apnsBroker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = deviceToken,
                    Payload = JObject.Parse("{\"aps\":{\"alert\":\" Test Message\", \"badge\":1, \"sound\":\" default\",}}")
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            apnsBroker.Stop();
            return View(message);
        }

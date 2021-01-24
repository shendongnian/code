    using Alexa.NET.Response
    using Alexa.NET.Reminders
    ....
    var reminder = new Reminder
    {
        RequestTime = DateTime.UtcNow,
        Trigger = new RelativeTrigger(12 * 60 * 60),
        AlertInformation = new AlertInformation(new[] { new SpokenContent("it's a test", "en-GB") }),
        PushNotification = PushNotification.Disabled
    };
    var client = new RemindersClient(skillRequest);
    var alertDetail = await client.Create(reminder);
    Console.WriteLine(alertDetail.AlertToken);

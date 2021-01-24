    public async Task WelcomeToTheApplicationAsync(User user)
    {
        await _notificationPublisher.PublishAsync(
            AppNotificationName.WelcomeToTheApplication,
            new SendNotificationData("Naeem", "Hello I have sended this notification to you"),
            severity: NotificationSeverity.Success,
            userIds: new[] { user.ToUserIdentifier() }
        );
    }

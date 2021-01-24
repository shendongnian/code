    public async Task<RegisterOutput> Register(RegisterInput input)
    {
        var user = await _userRegistrationManager.RegisterAsync(
            input.Name,
            input.Surname,
            input.EmailAddress,
            input.UserName,
            input.Password,
            true
        );
>
        _notificationSubscriptionManager.SubscribeToAllAvailableNotifications(user.ToUserIdentifier());
        await _appNotifier.WelcomeToTheApplicationAsync(user);

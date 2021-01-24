<!-- -->
    public class WelcomeNotificationJob : BackgroundJob<UserIdentifier>, ITransientDependency
    {
        private readonly IRealTimeNotifier _realTimeNotifier;
        private readonly IUserNotificationManager _userNotificationManager;
        public WelcomeNotificationJob(
            IRealTimeNotifier realTimeNotifier,
            IUserNotificationManager userNotificationManager)
        {
            _realTimeNotifier = realTimeNotifier;
            _userNotificationManager = userNotificationManager;
        }
        [UnitOfWork]
        public override void Execute(UserIdentifier args)
        {
            var notifications = _userNotificationManager.GetUserNotifications(args);
            AsyncHelper.RunSync(() => _realTimeNotifier.SendNotificationsAsync(notifications.ToArray()));
        }
    }

    public static readonly DependencyProperty NotificationsProperty = DependencyProperty.RegisterAttached(
        "Notifications",
        typeof(ObservableCollection<Notification>),
        typeof(Squiggle),
        new FrameworkPropertyMetadata(null, NotificationsPropertyChanged, CoerceNotificationsPropertyValue));

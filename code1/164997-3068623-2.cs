    public interface INotificationsService : IObservable<ReceivedNotification>
    {
        /// <summary>
        /// Gets or sets the ID for this notification service. May only be set once.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The setter was called more than once, or the getter was called before the
        /// ID was initialized.
        /// </exception>
        string ID { get; set; }
    
        void IssueNotifications(IEnumerable<ClientIssuedNotification> notifications);
    }

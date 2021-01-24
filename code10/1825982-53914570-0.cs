    public class ApplicationUser
    {
        ...
        public ICollection<NotificationUser> Notifications { get; set; }
    }
    public class Notification
    {
        ...
        public ICollection<NotificationUser> Users { get; set; }
    }
    public class NotificationUser
    {
        public int ApplicationUserId { get; set; }
        public int NotificationId { get; set; }
        public ApplicationUser User { get; set; }
        public Notification Notification { get; set; }
    }

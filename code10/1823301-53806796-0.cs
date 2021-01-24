    public class RootObject
    {
        public List<Dictionary<string, NotificationInfo>> Notifications { get; set; }
    }
    public class NotificationInfo
    {
        public int TargetId { get; set; }
        public bool Digest { get; set; }
    }

    public class Preferences
    {
        public List<Dictionary<string, NotificationInfo>> Notifications { get; set; }
    }
    public class NotificationInfo
    {
        public int TargetIntId { get; set; }
        public bool Digest { get; set; }
    }

    public class QueueItem
    {
        public string Key { get; set; }
        public int IssueNumber { get; set; }
    }
    public class ResponseModel
    {
        public string newStatus { get; set; }
        public List<QueueItem> queueItems { get; set; }
    }

    public class TaskSearchCriteria
    {
        public List<int> Statuses { get; set; }
        public List<int> Severities { get; set; }
        public List<int> CreatedBy { get; set; }
        public List<int> ClosedBy { get; set; }
        public List<int> LastModificationBy { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
        public bool SearchInComments { get; set; }
        public bool SearchInContent { get; set; }
        public bool SearchInTitle { get; set; }
    }

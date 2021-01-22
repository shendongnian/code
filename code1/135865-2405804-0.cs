    public class TaskSearchCriteria
    {
        public List<int> Statuses { get; set; }
        public List<int> VersionsReported { get; set; }
        public List<int> VersionsResolved { get; set; }
        public List<int> Severities { get; set; }
        public List<int> Priorities { get; set; }
        public List<int> Platforms { get; set; }
        public List<int> OperationSystems { get; set; }
        public List<int> Groups { get; set; }
        public List<int> AssignedTo { get; set; }
        public List<int> CreatedBy { get; set; }
        public List<int> ClosedBy { get; set; }
        public List<int> LastModificationBy { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
        public DateTime? LastModificationDateFrom { get; set; }
        public DateTime? LastModificationDateTo { get; set; }
        public DateTime? ClosedDateFrom { get; set; }
        public DateTime? ClosedDateTo { get; set; }
        public bool SearchInComments { get; set; }
        public bool SearchInContent { get; set; }
        public bool SearchInTitle { get; set; }
    }

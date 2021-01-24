    public class WorkItemForRollup
    {
        public Guid JobID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
    
    public class JobForRollup
    {
        public Guid JobID { get; set; }
        public string JobName { get; set; }
        public decimal Price { get; set; }
        public DateTime ScheduledStart { get; set; }
        public List<WorkItemForRollup> WorkItems { get; set; } = new List<WorkItemForRollup();
    }
    
    public class ProjectRollup
    {
        public decimal Total { get; set; }
        public List<JobForRollup> Jobs { get; set; } = new List<JobForRollup>();
    }

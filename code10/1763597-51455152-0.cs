    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }
        public int Job_JobID {get;set;} 
        [ForeignKey("Job_JobID")]
        public virtual Job Job { get; set; }
    
    }

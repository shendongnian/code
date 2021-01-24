    public class Issue : BaseEntity
    {
        [Key]
        public int Id { get; set; }
    
        //Foreign key for Reporter (User entity)
        public int ReporterId { get; set; } //<--- instead of short, it should be int
    
        //Foreign key for Assignee (User entity)
        public int AssigneeId { get; set; } //<--- instead of short, it should be int
    
        [ForeignKey("ReporterId")]
        public virtual User Reporter { get; set; }
    
        [ForeignKey("AssigneeId")]
        public virtual User Assignee { get; set; }
    }

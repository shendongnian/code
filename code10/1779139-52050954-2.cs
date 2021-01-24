    public class Menu : IAudit, ISoftDeletable
    {
        public long Id { get; set; }
        ..........
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }

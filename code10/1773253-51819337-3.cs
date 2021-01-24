    public class Process
    {
        public long ID { get; set; }
        public long? ParentID { get; set; }
    
        [InverseProperty("Children")]
        public Process Parent { get; set; }
        public virtual ICollection<Process> Children { get; set; }
    }

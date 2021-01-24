    public class Package
    {
        public int PackageId { get; set; } 
        public string From { get; set; } 
        public string To { get; set; } 
        public DateTime Created { get; set; } 
    
        public virtual ICollection<Action> Actions { get; set; } 
    }
    
    public class Action
    {
        public int PackageId { get; set; } 
        public int StaffId { get; set; } 
        public string Action   { get; set; } 
        public DateTime UpdateDate { get; set; } 
    }

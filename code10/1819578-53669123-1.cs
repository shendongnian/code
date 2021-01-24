    public class group_roles
    {
        [Key]
        public int group_roles_id { get; set; }
    
        [ForeignKey("groups")]
        public int group_id { get; set; }
        
        [ForeignKey("roles")]
        public int role_id { get; set; }
    
        public virtual group { get; set; }
        public virtual role { get; set; }
    }

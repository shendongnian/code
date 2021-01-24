    [Table("ProxyUserGroups")]
    public class ProxyUserGroup
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; } 
    }

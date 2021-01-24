    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class RolePermission
    {
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(Permission))]
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }

    public class UserRole : IdentityUserRole<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public override int RoleId { get; set; }
        public override int UserId { get; set; }
        [ForeignKey("RoleId")] // Specify ForeignKey Column Name
        public virtual Role Role { get; set; }
        [ForeignKey("UserId")] // Specify ForeignKey Column Name
        public virtual User User { get; set; }
    }

    public class UserRole : IdentityUserRole<int>
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [ForeignKey("Role")] // Specify Table name on Property
            public override int RoleId { get; set; }
            [ForeignKey("User")] // Specify Table name on Property
            public override int UserId { get; set; }
            public virtual Role Role { get; set; }
            public virtual User User { get; set; }
        }

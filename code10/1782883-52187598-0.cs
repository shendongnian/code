    public class AspNetUserRolesExtendedDetails
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("ApplicationUser")]
        public String UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("AspNetRolesExtendedDetails")]
        public String RoleId { get; set; }
        public virtual AspNetRolesExtendedDetails AspNetRolesExtendedDetails { get; set; }
    }

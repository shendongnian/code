    public class ApplicationUser
    {
        public List<UserRole> UserRoles { get; set; }
    }
    public class UserRole
    {
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set }
        public string RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public IdentityRole Role { get; set }
    }
    IQueryable<ApplicationUser> GetUsers(IdentityDb db)
    {
        return db.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);
    }

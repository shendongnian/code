    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserFollow> Following { get; set; }
        public virtual ICollection<UserFollow> Followers { get; set; }
        public virtual ICollection<UserBlock> BlockedUsers { get; set; }
    }
    public class UserFollow
    {
        public int Id { get; set; }
        [ForeignKey(nameof(SourceUserId))]
        public ApplicationUser SourceUser { get; set; }
        public string SourceUserId { get; set; }
        [ForeignKey(nameof(FollowedUserId))]
        public ApplicationUser FollowedUser { get; set; }
        public string FollowedUserId { get; set; }
    }
    public class UserBlock
    {
        public int Id { get; set; }
        [ForeignKey(nameof(SourceUserId))]
        public ApplicationUser SourceUser { get; set; }
        public string SourceUserId { get; set; }
        [ForeignKey(nameof(BlockedUserId))]
        public ApplicationUser BlockedUser { get; set; }
        public string BlockedUserId { get; set; }
    }

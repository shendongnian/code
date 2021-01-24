    public class HostUser : IdentityUser
    {
        public virtual ICollection<GuestUser> GuestUsers { get; set; }
    }
    public class GuestUser
    {
        public int HostUserId { get; set; }
        public virtual HostUser HostUser { get; set; }
    }

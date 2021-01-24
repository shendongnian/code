    public class UserDetails
    {
        [ForeignKey(nameof(UserKey))]
        public string UserId { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public Uri FacebookLink { get; set; }
        public Uri TwitterLink { get; set; }
        public Uri SkypeLink { get; set; }
    
        public virtual User UserKey { get; set; }
    }

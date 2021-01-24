    public class UserVolunteer
    {
        public string userId { get; set; }
        public AppUser user { get; set; }
    
        public int initiativeId { get; set; }
        public Initiative initiative { get; set; }
    }

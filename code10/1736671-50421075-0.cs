    public class Community
    {
        public string Name { get; set; }
        public string SiteUrl { get; set; }
        public string LoginUrl { get; set; }
        public List<CommunityUser> Users { get; set; }
    }
    public class CommunityUser
    {
        public string UserID { get; set; }
        public string VaultKeyName { get; set; }
    }

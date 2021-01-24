    public class UploadFile
    {
    
        public int Id { get; set; }
        public string UserId { get; set; } 
        public byte[] md5 { get; set; }
        public string Uri { get; set; }
        public string ThumbnialUri { get; set; }
        public ApplicationUser ApplicationUser { get; set; } //this user is extend from `IdentityUser`
    }

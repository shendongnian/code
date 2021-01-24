    public class ApplicationUser : IdentityUser<Guid>
    {
        public DateTime JoinTime { get; set; } = DateTime.Now;
        public DateTime DOB { get; set; } = Convert.ToDateTime("01-Jan-1900");
    }
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }

    public class MainDbContext: IdentityDbContext<AppUser>
    {
        public DbSet<Blog> Blogs { get; set; }
    }
    public class Blog 
    {
        //Some properties
        public int EditorId { get; set; }
        public AppUser Editor { get; set; }
    }

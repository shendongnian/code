    public class Project
    {
        ...
        public List<Image> Images { get; set; }
    }
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url{ get; set; }
    }
    public class MyContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }
    }

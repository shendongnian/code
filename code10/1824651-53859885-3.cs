    public class SchoolContext: DbContext 
    {
        public SchoolContext(): base()
        {
            
        }
            
        public DbSet<Student> Students { get; set; }
    }

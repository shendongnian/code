    public class SampleContext : DbContext
    {
        public SampleContext(string connection) : base(connection)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TaskContext>());
        }
        public DbSet<Task> Tasks { get; set; }
    }

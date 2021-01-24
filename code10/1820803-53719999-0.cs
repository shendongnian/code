    class Archive
    {
        public int Id {get; set;}
        public DateTime IssuingDate {get; set;}
        public string InsertedBy {get; set;}
        ...
    }
    public class MyDbContext : DbContext
    {
         public DbSet<Archive> Archives {get; set;}
    }

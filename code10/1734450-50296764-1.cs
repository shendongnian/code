    public class Tag
    {
        public int16 Count { get; set; } 
        // or, 
       /* public short Count { get; set; } */
    
        //Other properties
    }
    
    //In DbContext
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Tag>().Property(m => m.Count).HasColumnType("smallint");
    }
    
    //query
    var tags = await context.Tags.ToArrayAsync();

    public class MyEntity
    {
        // ...
        public DateTime DateVal { get; set; }
    }
    modelBuilder.Entity<MyEntity>()
    	.Property(e => e.DateVal)
    	.HasColumnType("date");

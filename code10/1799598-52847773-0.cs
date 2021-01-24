    public class DynamicQueryDbContext : AppDbContext
    {
        protected int MinPriority => Program.MinPriority;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupItem>()
                .HasQueryFilter(x => x.Priority >= MinPriority);
        }
    }

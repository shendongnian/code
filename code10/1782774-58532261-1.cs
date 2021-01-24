    public partial class RRStoreContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder builder)
        {
            builder.Entity<RepeatOrderSummaryView>().HasNoKey();
        }
    }

    public partial class SomeContext : DbContext
    {
        public virtual DbSet<SomeTable> SomeTable { get; set; }
        ....
    }

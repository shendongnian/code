cs
public class Wine
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineVariantId WineVariantId { get; set; }
    public WineVariant WineVariant { get; set; }
}
public enum WineVariantId : int
{
    Red = 0,
    White = 1,
    Rose = 2
}
public class WineVariant
{
    public WineVariantId WineVariantId { get; set; }
    public string Name { get; set; }
    public List<Wine> Wines { get; set; }
}
Here the `DbContext` where you configure value conversions and data seeding:
cs
public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<WineVariant> WineVariants { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=wines.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineVariantId)
            .HasConversion<int>();
        modelBuilder
            .Entity<WineVariant>()
            .Property(e => e.WineVariantId)
            .HasConversion<int>();
        modelBuilder
            .Entity<WineVariant>().HasData(
                Enum.GetValues(typeof(WineVariantId))
                    .Cast<WineVariantId>()
                    .Select(e => new WineVariant()
                    {
                        WineVariantId = e,
                        Name = e.ToString()
                    })
            );
    }
}
Then you can use the enum values in your code as follow:
cs
db.Wines.Add(new Wine
{
    Name = "Gutturnio",
    WineVariantId = WineVariantId.Red,
});
db.Wines.Add(new Wine
{
    Name = "Ortrugo",
    WineVariantId = WineVariantId.White,
});
Here is what your db will contain:
[![WineVariants table][1]][1]
[![Wines table][2]][2]
I published the complete example as a gist: https://gist.github.com/paolofulgoni/825bef5cd6cd92c4f9bbf33f603af4ff
  [1]: https://i.stack.imgur.com/UzhTj.png
  [2]: https://i.stack.imgur.com/2z88t.png

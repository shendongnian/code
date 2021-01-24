    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Category");
            });
            builder.Entity<CategoryTranslation>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired();
                b.HasOne(x => x.Category)
                    .WithMany(c => c.Translations)
                    .HasForeignKey(x => x.CategoryId);
                b.HasOne(x => x.Language)
                    .WithMany(l => l.CategoryTranslations)
                    .HasForeignKey(x => x.LanguageId);
                b.ToTable("CategoryTranslation");
            });
            builder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Country).IsRequired();
                b.Property(x => x.Code).IsRequired();
                b.ToTable("Language");
            });
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Language> Languages { get; set; }
    }

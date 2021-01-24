    public class PrincipalEntity
    {
        [Key]
        public int Id { get; set; }
        public string PrincipalProperty { get; set; }
        public virtual DependentEntity Dependent { get; set; }
    }
    public class DependentEntity
    {
        [Key]
        public int Id { get; set; }
        public string DependentProperty { get; set; }
    }
    public class PricipalEntityConfiguration : IEntityTypeConfiguration<PrincipalEntity>
    {
        public void Configure( EntityTypeBuilder<PrincipalEntity> builder )
        {
            //builder.HasKey( pe => pe.Id );
            builder.HasOne( pe => pe.Dependent )
                .WithOne()
                .HasForeignKey<DependentEntity>( de => de.Id ); // FK is PK
            builder.ToTable( "YourTableName" );
        }
    }
    public class DependentEntityConfiguration : IEntityTypeConfiguration<DependentEntity>
    {
        public void Configure( EntityTypeBuilder<DependentEntity> builder )
        {
            //builder.HasKey( de => de.Id );
            builder.ToTable( "YourTableName" ); // same table name
        }
    }
    public class TestContext : DbContext
    {
        public DbSet<PrincipalEntity> PrincipalEntities { get; set; }
        public DbSet<DependentEntity> DependentEntities { get; set; }
        public TestContext( DbContextOptions options ) : base( options )
        {
        }
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new PricipalEntityConfiguration() );
            modelBuilder.ApplyConfiguration( new DependentEntityConfiguration() );
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseSqlServer( "Server=(localdb)\\mssqllocaldb;Database=EFCoreTest;Trusted_Connection=True;" )
                .Options;
            using( var dbContext = new TestContext( options ) )
            {
                var pEntity = new PrincipalEntity()
                {
                    PrincipalProperty = "Principal Property Value",
                    Dependent = new DependentEntity()
                    {
                        DependentProperty = "Dependent Property Value",
                    },
                };
                dbContext.PrincipalEntities.Add( pEntity );
                dbContext.SaveChanges();
            }
            using( var dbContext = new TestContext( options ) )
            {
                var pEntity = dbContext.PrincipalEntities
                    // eager load dependent
                    .Include( pe => pe.Dependent )
                    .Single();
                System.Console.WriteLine( "Loaded Principal w/ Dependent Eager-Loaded:" );
                DisplayValues( pEntity );
                dbContext.Entry( pEntity.Dependent ).State = EntityState.Detached;
                dbContext.Entry( pEntity ).State = EntityState.Detached;
                pEntity = dbContext.PrincipalEntities.Single();
                System.Console.WriteLine();
                System.Console.WriteLine( "Load Principal Entity Only:" );
                DisplayValues( pEntity );
                // explicitly load dependent
                dbContext.Entry( pEntity )
                    .Reference( pe => pe.Dependent )
                    .Load();
                System.Console.WriteLine();
                System.Console.WriteLine( "After Explicitly Loading Dependent:" );
                DisplayValues( pEntity );                
            }
        }
        private static void DisplayValues( PrincipalEntity pe )
        {
            System.Console.WriteLine( $"Principal Entity = {{ Id: {pe.Id}, PrincipalProperty: \"{pe.PrincipalProperty}\" }}" );
            if( null == pe.Dependent )
            {
                System.Console.WriteLine( "Principal Entity's Dependent property is null" );
            }
            else
            {
                System.Console.WriteLine( $"Dependent Entity = {{ Id: {pe.Dependent.Id}, DependentProperty: \"{pe.Dependent.DependentProperty}\" }}" );
            }
        }

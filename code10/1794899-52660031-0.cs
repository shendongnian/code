    public class SplitTablePrincipal
    {
        [Key]
        public int Id { get; set; }
        public string PrincipalProperty { get; set; }
        // principal entity has a nav property to the dependent entity
        public virtual SplitTableDependent Dependent { get; set; }
    }
    public class SplitTableDependent
    {
        [Key]
        public int Id { get; set; }
        public string DependentProperty { get; set; }
    }
    public class SplitTablePricipalConfiguration : IEntityTypeConfiguration<SplitTablePrincipal>
    {
        public void Configure( EntityTypeBuilder<SplitTablePrincipal> builder )
        {
            //builder.HasKey( pe => pe.Id );
            // establish 1:? relationship w/ shared primary key
            builder.HasOne( pe => pe.Dependent )
                .WithOne()
                .HasForeignKey<SplitTableDependent>( de => de.Id ); // FK is PK
            builder.ToTable( "YourTableName" );
        }
    }
    public class SplitTableDependentConfiguration : IEntityTypeConfiguration<SplitTableDependent>
    {
        public void Configure( EntityTypeBuilder<SplitTableDependent> builder )
        {
            //builder.HasKey( de => de.Id );
            // map dependent entity to same table as principal
            builder.ToTable( "YourTableName" ); // same table name
        }
    }

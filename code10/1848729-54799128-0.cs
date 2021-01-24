    public class FooConfiguration : IEntityTypeConfiguration<Foo>
    {
        public void Configure(EntityTypeBuilder<Foo> builder)
        {
    		...
    		builder.HasIndex(h => h.Column1).IsUnique();
            builder.HasIndex(h => h.Column2).IsUnique();
           ..
    	}
    }

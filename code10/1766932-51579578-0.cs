    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
    	public void Configure(EntityTypeBuilder<Car> builder)
    	{
    		builder.HasKey(a => a.Id);
    		builder.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
    		builder.HasOne(x => x.CarOwner)
    			.WithMany(x => x.Cars)
    			.HasForeignKey("CarOwner_Id") // <--
    			.IsRequired(false);
    	}
    }
    
    public class CarOwnerConfiguration : IEntityTypeConfiguration<CarOwner>
    {
    	public void Configure(EntityTypeBuilder<CarOwner> builder)
    	{
    		builder.HasKey(a => a.Id);
    		builder.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
    	}
    }

    public class FirstEntityConfiguration : EntityTypeConfiguration<FirstEntity>
    {
        public FirstEntityConfiguration()
        {
            Map(x => x.MapInheritedProperties());
            ToTable("FirstEntity");
            HasKey(x => x.Id);
    
            HasMany(x => x.History)
                .WithOptional(x => (FirstEntity)x.Module)
                .Map(x => x.MapKey("ModuleId"));
        }
    }
    
    public class SecondEntityConfiguration : SecondEntityConfiguration<SecondEntity>
    {
        public SecondEntityConfiguration()
        {
            Map(x => x.MapInheritedProperties());
            ToTable("SecondEntity");
            HasKey(x => x.Id);
    
            HasMany(x => x.History)
                .WithOptional(x => (SecondEntity)x.Parent)
                .Map(x => x.MapKey("ModuleId"));
        }
    }
    
    public class ModuleHistoryConfiguration : EntityTypeConfiguration<ModuleHistory>
    {
        public ModuleHistoryConfiguration()
        {
            ToTable("ModuleHistory");
            HasKey(x => x.Id);
        }
    }
    
    // This mapping is needed because ModuleHistory's reference to BaseEntity. EF needs to know there is a Key.
        public class BaseEntityConfiguration : EntityTypeConfiguration<BaseEntity>
        {
            public BaseEntityConfiguration()
            {
                HasKey(x => x.Id);
            }
        }

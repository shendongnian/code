    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("Persons");
            HasKey(x => x.PersonId)
                .Property( x=> x.PersonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasOne(x => x.User)
                .WithRequiredDependency()
                .HasForeignKey(x => x.PersonId);
        }
    }
    
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public PersonConfiguration()
        {
            ToTable("Users");
            HasKey(x => x.PersonId);
        }
    }

    public class PersonEntityMap : AuditableEntityMap<Person, int>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            // Properties
            builder.Property(t => t.Name).IsRequired();
            // etc...
        }
    }

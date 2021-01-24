    public class StudentConfigurations : BaseEntityConfigurations<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder); // Must call this
    
           // composite key
            builder.HasKey(c => new { c.Key, c.Id });
        }
    }

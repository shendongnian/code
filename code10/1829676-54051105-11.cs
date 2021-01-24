    public class StudentConfigurations : BaseEntityConfigurations<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder); // Must call this
           
           // other configurations here
        }
    }

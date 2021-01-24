    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.LastLoginDateTime).HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }

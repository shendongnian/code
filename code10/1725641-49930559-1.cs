    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(t => t.Full_Name);
            //table  
            builder.ToTable("People");
            //relationships
            builder.HasMany(s => s.PM_Projects).WithOne(o=>o.PM_Person).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.PTL_Projects).WithOne(o => o.PTL_Person).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(t => t.Project_Name);
            //table  
            builder.ToTable("Projects");
            //relationships
            builder.HasOne(s => s.PM_Person).WithMany(d=>d.PM_Projects).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.PTL_Person).WithMany(d => d.PTL_Projects).OnDelete(DeleteBehavior.Restrict);
            
        }
    }

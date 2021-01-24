    > public class MyContext : DbContext
    >     {
    >         public DbSet<Curriculum> Curriculum { get; set; }
    >         public DbSet<Course> Course { get; set; }
    > 
    >         protected override void OnModelCreating(DbModelBuilder modelBuilder)
    >         {
    >             base.OnModelCreating(modelBuilder);
    >             modelBuilder.Configurations.Add(new CourseConfiguration());
    >         }
    >     }
    >     public class Course
    >     {
    >         [DatabaseGenerated(DatabaseGeneratedOption.None)]
    >         public int Id { get; set; }
    >         public Curriculum Curriculum { get; set; }
    >     }
    > 
    >     public class CourseConfiguration : EntityTypeConfiguration<Course>
    >     {
    >         public CourseConfiguration()
    >         {
    >             HasOptional(course => course.Curriculum)
    >                 .WithRequired(cur => cur.Course);
    >         }
    >     }
    >     public class Curriculum
    >     {
    >         [ForeignKey("Course")]
    >         public int Id { get; set; }
    > 
    >         public Course Course { get; set; }
    >     }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Parent>().HasMany(g => g.Students);
    base.OnModelCreating(modelBuilder);
}
 2. Have you assigned values to each other when seeding
var parentId = 1;
var student = new Student
{
   ParentId = parentId
}
....
var parent = new Parent()
{
   ID = parentId
   Students = {student}
}

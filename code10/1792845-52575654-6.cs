    public class SchoolContext: DbContext 
    {
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
         modelBuilder.Entity<Student>()
            .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("InsertStudent").Parameter(pm => pm.StudentName, "name").Result(rs => rs.StudentId, "Id"))
                .Update(sp => sp.HasName("UpdateStudent").Parameter(pm => pm.StudentName, "name"))
                .Delete(sp => sp.HasName("DeleteStudent").Parameter(pm => pm.StudentId, "Id"))
            );
       }
    }

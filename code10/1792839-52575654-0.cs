    modelBuilder.Entity<Student>()
            .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertStudent").Parameter(pm => pm.StudentName, "name").Result(rs => rs.StudentId, "Id"))
                    .Update(sp => sp.HasName("sp_UpdateStudent").Parameter(pm => pm.StudentName, "name"))
                    .Delete(sp => sp.HasName("sp_DeleteStudent").Parameter(pm => pm.StudentId, "Id"))
            );

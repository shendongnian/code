    protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
        IDictionary<object, object> items)
    {
 
        if (entityEntry.Entity is Course &&
	                (entityEntry.State == EntityState.Added 
	                  || entityEntry.State == EntityState.Modified))
        {
            var courseToCheck = ((Course)entityEntry.Entity);
 
            //check for uniqueness 
            if (Courses.Any(c => c.Name == course.Name && c.Department.ID == course.Department.ID)))
                return 
	                   new DbEntityValidationResult(entityEntry,
                     new List<DbValidationError>
                         {
                             new DbValidationError( "Name",
                                 $"Cannot create a course with name {courseToCheck .Name} in {courseToCheck .Department.Name} department because a course with this name already exists in this department.")
                         });
        }
 
        return base.ValidateEntity(entityEntry, items);
    }

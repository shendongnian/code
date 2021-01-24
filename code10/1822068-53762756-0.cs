    using (var context = new SchoolContext())
    {
 
        try
        {
            
            context.Students.Add(new Student()
            {
                FirstName = "Rama2",
                StandardId = standard.StandardId
            });
            context.Courses.Add(new Course() { CourseName = "Computer Science" });
            context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("Error occurred.");
        }
    }

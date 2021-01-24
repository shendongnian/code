    public class Student
    {
       public int Id {get;set;}
       public string Name {get;set;} // and other names and age and so on
       public ICollection<Class> Classes {get;set;} // classes to which student attends
    }
    
    // your context
    
    public class dbStudentEntities : DbContext
    {
       public DbSet<Student> tblStudents {get;set;} // in CodeFirst this is enough to also create Classes table
    }
    
    //    then to populate DataGrid:
    
    using(var ctx = new dbStudentEntities()) // this is your context, disposing it is important
    {
       var students = ctx.Students.Include(x => x.Classes).ToList(); // Student.Classes is not virtual, so we don't have lazy loading, but making it virtual creates ugly proxy. You can read up on that
       dataGrid.ItemsSource = students;
    }

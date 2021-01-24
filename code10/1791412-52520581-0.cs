    public interface IDbSchool
    {
        IQueryable<Student> Students {get;}
        IQueryable<Teacher> Teachers {get;}
        IQueryable<ClassRoom> ClassRooms {get;}
        IQueryable<Course> Courses {get;}
    }
    internal class DbSchool : DbContext, IDbSchool
    {
         internal DbSet<Student> Students {get; set;}
         internal DbSet<Teachter> Teachers {get; set;}
         ...
         // Explicit interface implementation of IDbSchool:
         IQueryable<Student> IDbSchool.Students {get => this.Students;}
         IQueryable<Teacher> IDbSchool.Teachers {get => this.Teachers;}
         ...
    }

    interface IId
    {
         public int Id {get;}
    }
    class Teacher : IId {...}
    class Student: IId {...}
    class Grade: IId {...}
    interface ISchoolQuerier
    {
        IQueryable<Teacher> Teachers {get; }
        IQueryable<Student> Students {get;}
        IQueryable<Grade> Grades {get;}
    }
    class SchoolDbContext : DbContext
    {
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Grades> {get; set;}
        // explicit interface implementation
        IQueryable<Teacher> ISchoolQuerier.Teachers {get{return this.Teachers;}}
        IQueryable<Student> ISchoolQuerier.Students {get{return this.Students;}}
        IQueryable<Grade> ISchoolQuerier.Grades{get{return this.Grades;}}
    }

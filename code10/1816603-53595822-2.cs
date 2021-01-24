    public interface IArchive : IDisposable
    {
        IQueryable<School> Schools {get; set;}
        IQueryable<Teacher> Teachers {get; set;}
        IQueryable<Student> Students {get; set;}
    }
    public class Archive : IArchive, IDisposable
    {
         private readonly DbContext = new SchoolDbContext(...);
         public IQueryable<School> Schools => this.DbContext.Schools;
         public IQueryable<Teacher> Teachers => this.DbContext.Teachers;
         public IQueryable<Student> Students => this.DbContext.Students;
         public int SaveChanges()
         {
             return this.DbContext.SaveChanges();
         }
         // TODO: Dispose disposes the DbContext
    }

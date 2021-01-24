    public interface IHasId
    {
        int Id { get; set; }
    }
    public interface IHasName
    {
        string FirstName { get;  }
        string LastName { get;  }
    }
    public class Employee : IHasName, IHasId
    {
        [Column("Forename")] //this ensures it is still called "Forename" in the database
        public string FirstName { get; set; }
        [Column("Surname")]
        public string LastName { get; set; }
        [Column("EmployeeId")]//this ensures you are following DB best practice through the same technique as above
        public int Id { get; set; }
    }
    public class User : IHasName, IHasId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column("UserId")]
        public int Id { get; set; }
        //equally you could add
        [notmapped]
        public string FullName => $"{FirstName} {LastName}"; 
     //or add this as an extension function for all IHasName
    }
    public class Job: IHasName, IHasId
    {
        public string Name { get; set; }
        [NotMapped] //not mapped tells entity framework you dont want these fields in the DB, so in the DB their would only be "name" but in your code, firstname & lastname are pseudonyms for Name 
        public string FirstName => Name;
        [NotMapped]
        public string LastName => Name;
        [Column("JobId")]
        public int Id { get; set; }
       
    }
    public class ModelContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
    public static class GenericExtensions
    {
        public static IQueryable<TModel> GetById<TModel>(this IQueryable<TModel> db, int Id) where TModel : class, IHasId
        {
            return db.Where(x => x.Id == Id);
        }
        public static IQueryable<TModel> GetByAnyName<TModel>(this IQueryable<TModel> db, string name) where TModel : class, IHasName
        {
            return db.Where(x => x.FirstName == name || x.LastName == name);
        }
        public static IQueryable<TModel> GetByFirstAndLastName<TModel>(this IQueryable<TModel> db, string firstName, string lastName) where TModel : class, IHasName
        {
            return db.Where(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ModelContext context = new ModelContext();
            var filteredEmpl =context.Employees.GetByAnyName("John").GetById(1);
            var filteretJobs =context.Jobs.GetByAnyName("Supervisor").GetById(1);
            var filteredUsers =context.Users.GetByFirstAndLastName("Terry","Richards").GetById(1);
        }
    }

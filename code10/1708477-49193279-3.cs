    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(c =>
            {
                c.For<IService>().Use<Service>();
                // Register the generic repository for any entity
                c.For(typeof(IRepository<>)).Use(typeof(Repository<>));
            });
            // Resolve the service
            var service = container.GetInstance<IService>();
        }
    }
    public class Company { }
    public class Employee { }
    public class Timecard { }
    public interface IService { }
    public class Service : IService
    {
        public Service(
            IRepository<Company> companyRepo, 
            IRepository<Employee> employeeRepo, 
            IRepository<Timecard> timecardRepo)
        {
            // All 3 repositories injected here
        }
    }

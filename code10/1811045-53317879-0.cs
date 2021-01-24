    public class User : IHasKey
    {
        public string FirstName { get; set; }
        public string Key => FirstName;
    }
    public class Car : IHasKey
    {
        public string Model { get; set; }
        public string Key => Model;
    }
    public class Company : IHasKey
    {
        public string CompanyName { get; set; }
        public string Key => CompanyName;
    }
    public interface IHasKey
    {
        string Key { get; }
    }
    public class DataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public IEnumerable<IHasKey> GetByKey<T>(string value) where T: class, IHasKey
        {
            return this.Set<T>().Where(obj => obj.Key == value);
        }
    }

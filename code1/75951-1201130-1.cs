    public interface IQueryDirectory
    {
        ICustomerQueries Customer { get; }
        IUserQueries User { get; }
    }
    public interface ICustomerQueries
    {
       string Customers { get; }
       string CustomersById { get; }
    }
    public interface IUserQueries
    {
       string Users { get; }
       string UsersById { get; }
    }

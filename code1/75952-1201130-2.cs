    public abstract class QueryDirectory : IQueryDirectory
    {
        private ICustomerQueries customer;
        private IUserQueries user;
        public ICustomerQueries Customer 
        { 
            get { return customer; }
        }
        public IUserQueries User
        {
            get { return user; }
        }
        protected QueryDirectory(ICustomerQueries customer, IUserQueries user)
        {
            this.customer = customer;
            this.user = user;
        }
    }
    public class SqlServerQueryDirectory : QueryDirectory
    {
        public SqlServerQueryDirectory(SqlServerCustomerQueries customer,
            SqlServerUserQueries user) : base(customer, user) {}
    }
    public class SqlServerCustomerQueries : ICustomerQueries
    {
       public string Customers 
       {
           get "some sql";
       }
       public string CustomersById 
       { 
           get "some sql";
       }
    }

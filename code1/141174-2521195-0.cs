    public class CustomerRepository : NHibernateRepositoryWithTypedId<Customer, string>, ICustomerRepository
    {
        public List<Customer> FindByCountry(string countryName) {
            ICriteria criteria = Session.CreateCriteria(typeof(Customer))
                .Add(Expression.Eq("Country", countryName));
    
    
            return criteria.List<Customer>() as List<Customer>;
        }
    }

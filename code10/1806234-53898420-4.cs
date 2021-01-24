    public class CountryService : MultiTenantServices<Country, int>
        {
            IMultiTenantRepository<Country, int> _repository = null;
    
            public CountryService(IMultiTenantRepository<Country, int> repository) : base(repository)
            {
                _repository = repository;
            }

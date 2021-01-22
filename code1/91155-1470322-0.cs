    public class CachingRepository : ICustomerRepository
    {
        private readonly ICustomerRepository remoteRep;
        private readonly ICustomerRepository localRep;
        public CachingRepository(ICustomerRepository remoteRep, ICustomerRepository localRep)
        {
            this.remoteRep = remoteRep;
            this.localRep = localRep;
        }
        // implement ICustomerRepository...
    }

    public class DomainObjectsRepository
    {
        /// <summary>
        /// can not be instantiated, use <see cref="Instance"/> instead.
        /// </summary>
        protected DomainObjectsRepository()
        {
        }
        static DomainObjectsRepository()
        {
            Instance = new DomainObjectsRepository();
        }
        public static DomainObjectsRepository Instance { get; set; }
        public virtual ICustomerDao GetCustomerDao()
        {
            return new CustomerDao();
        }
    }
    public class DomainObjectsRepositoryMock : DomainObjectsRepository
    {
        public override ICustomerDao GetCustomerDao()
        {
            return new CustomerDaoMock();
        }
    }

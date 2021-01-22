    public class CACSService
    {
        public CACSService() {}
        public CACSService(IUserRepository Repository, IBusinessRepository businessRepository)
        {
            _IRepository = Repository;
            _IBusinessRepository = businessRepository;
        }
        private IUserRepository _IRepository;
        public IUserRepository Repository
        {
            get {
                 if (this._IRepository == null)
                      this._IRepository = new UserRepository();
                 return this._IRepository;
            }
        }
       // Add same for IBusinessRepository
    }

    public class DbConnection: IConnection 
    {
        // Code for managing DB Connection and data querying
    }
    public class ContactRepository: IContactRepository
    {
        private IDbConnection _dbConnection;
        public ContactRepository(IConnection dbConnection)
        {
            _dbConnection= dbConnection;
        }
        public Contact[] GetAllContacts()
        {
             // Add code to read from DB here
        }
    }
    public class ContactController : ApiController
    {
        private IContactRepository _contactRepository;
        public ContactController()
        {
            _contactRepository = <using any DI container resolve dependency with ContactRepository>;
        }
        public Contact[] Get()
        {
            return _contactRepository.GetAllContacts();        
        }
    }

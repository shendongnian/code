    public abstract class Repository<T> where T: class
    {
        public abstract T GetByID(int id);
        public abstract IQueryable<T> GetAll();
        public abstract T Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
    }
    
    public class RecipientRepository: Repository<Recipient>;
    {
        // ...
    
        public override IQueryable<Recipient> GetAll()
        {
            using (ISession session = /* get session */)
            {
                // Gets a query that will return all Recipient entities if iterated
                IQueryable<Recipient> query = session.Linq<Recipient>();
                return query;
            }
        }
    
        // ...
    }
    
    public class RecipientList
    {
        public IQueryable<Recipient> Recipients
        {
            RecipientRepository repository = new RecipientRepository();
            return repository.GetAll(); // Returns a query, does not evaluate, so does not hit database
        }
    }
    
    // Consuming RecipientList in some higher level service, you can now do:    
    public class RecipientService
    {
        public IList<Recipient> GetPagedList(int page, int size)
        {
            RecipientList list = // get instance of RecipientList
            IQueryable<Recipient> query = list.Recipients.Skip(page*size).Take(size); // Get your page
            IList<Recipient> listOfRecipients = query.ToList(); // <-- Evaluation happens here!
            reutrn listOfRecipients;
        }
    }

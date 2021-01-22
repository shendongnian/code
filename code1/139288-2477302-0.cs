    public interface IPhoneRepository 
    {
        IEnumerable<Phone> GetPhonesForUser(User user);
    }
    
    public class L2SPhoneRepository : IPhoneRepository
    {
        private readonly MyDataContext context;
        public L2SPhoneRepository(MyDataContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<Phone> GetPhonesForUser(User user)
        {
            return context.Phones.Where(p => p.User == user);
        }
    }

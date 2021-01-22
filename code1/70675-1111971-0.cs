    public class EntitiesRepository : IRepository
    {
        IEnumerable<Contact> IRepository<Contact>.Get()
        {
            // Return something
        }
        IEnumerable<Group> IRepository<Group>.Get()
        {
            // Return something
        }
        
        public IEnumerable<Contact> GetContacts()
        {
            return (this as IRepository<Contact>).Get();
        }
        public IEnumerable<Group> GetGroups()
        {
            return (this as IRepository<Group>).Get();
        }
    }

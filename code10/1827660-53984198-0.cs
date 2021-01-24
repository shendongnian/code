    public interface INewsletterUnitOfWork
    {
        IRepository<Newsletter> NewsLetters { get; }
        IRepository<ContactSubscription> ContactSubscriptions { get; }
    }
    public class NewsletterUnitOfWork : UowBase, INewsletterUnitOfWork
    {
        private IRepository<Newsletter> _newsletters;
        public IRepository<Newsletter> NewsLetters
        {
            get { return _newsletters ?? (_newsletters = new GenericRepository<Newsletter>(Context)); }
            private set { _newsletters = value; }
        }
        private IRepository<ContactSubscription> _contactSubscriptions;
        public IRepository<ContactSubscription> ContactSubscriptions
        {
            get { return _contactSubscriptions ?? (_contactSubscriptions = new GenericRepository<ContactSubscription>(Context)); }
            private set { _contactSubscriptions = value; }
        }
        public NewsletterUnitOfWork(IDatabaseFactory factory)
            : base(factory)
        { }
    }

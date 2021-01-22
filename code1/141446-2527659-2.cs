    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly YourDataContext _dataContext;
        public SubscriptionRepository(YourDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #region ISubscriptionRepository
        public IEnumerable<ISubscription> ListAll()
        {
            return ListCorporate()
                .Cast<ISubscription>()
                .Concat(ListIndividual().Cast<ISubscription>());
        }
        public IEnumerable<CorporateSubscription> ListCorporate()
        {
            return _dataContext.CorporateSubscriptions;
        }
        public IEnumerable<IndividualSubscription> ListIndividual()
        {
            return _dataContext.IndividualSubscriptions;
        }
        public void Insert(ISubscription subscription)
        {
            if(subscription is CorporateSubscription)
            {
                _dataContext.CorporateSubscriptions.InsertOnCommit((CorporateSubscription) subscription);
            }
            else if(subscription is IndividualSubscription)
            {
                _dataContext.IndividualSubscriptions.InsertOnCommit((IndividualSubscription) subscription);
            }
            else
            {
                // Forgive me, Liskov
                throw new ArgumentException(
                    "Only corporate and individual subscriptions are supported",
                    "subscription");
            }
        }
        #endregion
    }

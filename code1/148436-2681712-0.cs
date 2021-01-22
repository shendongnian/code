    public sealed class Subscriber
    {
        // other constructors ...
    
        // this constructor is not visible from outside.
        private Subscriber(DataContext dc, int id)
        {
           // this line should probably be in another method for reusability.
           this.subscription = dc._GetSubscription(id).SingleOrDefault();                
        }
    
        public IEnumerable<Subscriber> CreateSubscribers(IEnumerable<int> ids)
        {
            using (DataContext dc = new DataContext())
            {
    
               return ids.select(x => new Subscriber(dc, x));
            }            
    
        }
    
    }

    private readonly Bar bar = new Bar();
    public void HandExceptionOffToSomethingThatNeedsToBeStronglyTyped<T>(T ex) where T : Exception
    {
        ICollection<T> exceptions = bar.GetCollectionOfExceptions<T>();
        exceptions.Add(ex);
        // do other stuff
    }
    public class Bar
    {
        // value is object, because .net doesn't have covariance yet
        private Dictionary<Type, object> listsOfExceptions = new Dictionary<Type, object>();
        public ICollection<T> GetCollectionOfExceptions<T>()
        {
            if (!listsOfExceptions.ContainsKey(typeof(T)))
            {
                listsOfExceptions.Add(typeof(T), new List<T>());
            }
            return listsOfExceptions[typeof(T)] as List<T>;
        }
    }

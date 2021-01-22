    public abstract class BusinessObjectCollection<T> : ICollection<T> 
        where T : BusinessObject, new()
    {
        // Here is a method that returns an instance
        // of type "T"
        public T GetT()
        {
            // And as long as you have the "new()" constraint above
            // the compiler will allow you to create instances of
            // "T" like this
            return new T();
        }
    }

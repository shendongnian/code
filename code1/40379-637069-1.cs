    public class Customer<T>
        where T : Customer<T>
    {
        private T subClass;
        public IDictionary<string, object> GetProperties()
        {
            return subClass.GetProperties();
        }
    }

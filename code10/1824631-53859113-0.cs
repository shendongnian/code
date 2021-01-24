    public interface IDBCaller
    { 
        IEnumerable<User> RetrieveUserList();
    }
    public class Implementation1 : IDBCaller
    {
        public IEnumerable<User> RetrieveUserList()
        {
            return new List<User>();
        }
    }
    public class Implementation2 : IDBCaller
    {
        IDBCaller decoratedImplementation;
        public Implementation2(IDBCaller decoratedImplementation)
        {
            this.decoratedImplementation = decoratedImplementation;
        }
        public IEnumerable<User> RetrieveUserList()
        {
            return this.decoratedImplementation.RetrieveUserList();
        }
    }

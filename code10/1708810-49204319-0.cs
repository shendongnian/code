    public class Computer
    {
        // properties of the computer class
        public IList<User> Users;
        // IAvailabiity checker
        private readonly IAvailabilityChecker _checker;
        // constructor
        public Computer(IAvailabilityChecker checker)
        {
            this._checker = checker;
        }
        // operations
        public void AddUser()
        {
            if (this._checker.IsAvailable())
            {
                // add user
            }
        }
        public void RemoveUser()
        {
        }
    }
    public class User
    {
    }
    public interface IAvailabilityChecker
    {
        bool IsAvailable();
    }
    public class AvailabilityChecker
    {
        public bool IsAvailable()
        {
            // availability checker logic
            return true;
        }
    }

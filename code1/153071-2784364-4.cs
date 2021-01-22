    public class Account {
        // ...
        public string AccountId {
            get { return AccountId; } // infinite recursion
        }
        // ...
    }

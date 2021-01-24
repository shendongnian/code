    public class User {
        public bool hasPermissions() { // check database for permissions
            var ans = false; // ...
            return ans;
        }
    
        public Lazy<bool> cachedPermissions;
    
        public User() {
            UncachePermissions();
        }
        
        public void UncachePermissions() => cachedPermissions = new Lazy<bool>(() => hasPermissions());
    }

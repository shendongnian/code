    abstract class Authenticator {
       
       protected Dictionary<string,User> userCache;
       ...
       public User LoadUser(string name) {
            User user;
            if( userCache.TryGet(name, out user) ) return user;
            else {
                user = LoadFromStore(name);
                userCache.Add(name, user);
                return user;
            }
       }
       protected abstract User LoadFromStore(string name);
    }

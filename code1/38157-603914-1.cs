    class Cache : IUserRepository {
      private IUserRepository users = null;
      public User GetUser(string username){
        if (this.NotCached(username)){
          this.ToCache(this.users.GetUser(username));
        }
        return this.FromCache(username);
      }
    }

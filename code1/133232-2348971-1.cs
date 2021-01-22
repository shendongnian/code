    public class LazyUserRepository : IUserRepository
    {
        private IUserRepository uRep;
        public IUser SelectUser(int userId)
        {
            if (this.uRep == null)
            {
                this.uRep = new UserRepository();
            }
            return this.uRep.SelectUser(userId);
        }
    }

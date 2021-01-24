    public class UserBal
    {
        private readonly IRepositoryDal<User> _userRepositoryDal;
 
        public UserBal(IRepositoryDal<User> userRepositoryDal)
        {
            _userRepositoryDal = userRepositoryDal 
              ?? throw new ArgumentNullException(nameof(userRepositoryDal));
        }
        ...
    }

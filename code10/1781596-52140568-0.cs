    public class LoginManager : ILoginManager {
        private readonly IValidations _validations;
        private readonly IAccountRepository _accountDal;
    
        public LoginManager(IValidations validations, IAccountRepository accountDal) {
            _validations = validations;
            _accountDal = accountDal;
        }
    
        public User Login(User user) {
            if (user != null && _validations.IsValidAccount(user)) {
                return _accountDal.Login(user);
            }
            log.Error("User null or not valid");
            return null;
        }
    }

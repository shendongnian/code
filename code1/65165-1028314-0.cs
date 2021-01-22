    namespace Domain.Abstract {
    	public interface IRepository {
    		string ConnectionString { get; }
    	}
    }
    namespace Domain.Abstract {
    	public interface IUserRepository : IRepository {
    		MembershipUser CreateUser(Guid userId, string userName, string password, PasswordFormat passwordFormat, string passwordSalt,
    				string email, string passwordQuestion, string passwordAnswer, bool isApproved,
    				DateTime currentTimeUtc, bool uniqueEmail);
    		MembershipUser GetUser(Guid userId, bool updateLastActivity, DateTime currentTimeUtc);
     		PasswordData GetPasswordData(Guid userId, bool updateLastLoginActivity, DateTime currentTimeUtc);
    		void UpdatePasswordStatus(Guid userId, bool isAuthenticated, int maxInvalidPasswordAttempts, int passwordAttemptWindow, 
    					  DateTime currentTimeUtc, bool updateLastLoginActivity, DateTime lastLoginDate, DateTime lastActivityDate);
            //....
        }
    }
    namespace Domain.Abstract {
	  public interface IUserService {
		bool EnablePasswordRetrieval { get; }
		bool EnablePasswordReset { get; }
		bool RequiresQuestionAndAnswer { get; }
		bool RequiresUniqueEmail { get; }
		//....
		MembershipUser CreateUser(string applicationName, string userName, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved);
		MembershipUser GetUser(Guid userId, bool userIsOnline);
		bool ValidateUser(Guid userId, string password);
        //...
        }
    }
    namespace Domain.Concrete {
	  public class UserService : IUserService {
		private IUserRepository _userRepository;
		public UserService(IUserRepository userRepository) {
			_userRepository = userRepository;
		}
        //...
		public bool ValidateUser(Guid userId, string password) {
			// validate applicationName and password here
            bool ret = false;
			try {
				PasswordData passwordData;
				ret = CheckPassword(userId, true, true, DateTime.UtcNow, out passwordData);
			}
			catch (ObjectLockedException e) {
				throw new RulesException("userName", Resource.User_AccountLockOut);
			}
			return ret;
		}
    	private bool CheckPassword(Guid userId, string password, bool updateLastLoginActivityDate, bool failIfNotApproved,
									DateTime currentTimeUtc, out PasswordData passwordData) {
			passwordData = _userRepository.GetPasswordData(userId, updateLastLoginActivityDate, currentTimeUtc);
			if (!passwordData.IsApproved && failIfNotApproved)
				return false;
			string encodedPassword = EncodePassword(password, passwordData.PasswordFormat, passwordData.PasswordSalt);
			bool isAuthenticated = passwordData.Password.Equals(encodedPassword);
			if (isAuthenticated && passwordData.FailedPasswordAttemptCount == 0 && passwordData.FailedPasswordAnswerAttemptCount == 0)
				return true;
			_userRepository.UpdatePasswordStatus(userId, isAuthenticated, _maxInvalidPasswordAttempts, _passwordAttemptWindow,
												currentTimeUtc, updateLastLoginActivityDate,
												isAuthenticated ? currentTimeUtc : passwordData.LastLoginDate,
												isAuthenticated ? currentTimeUtc : passwordData.LastActivityDate);
			return isAuthenticated;
		}
    }

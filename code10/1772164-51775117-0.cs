    public class UserService : IUserService
    {
	    private IUserRepository _userRepository;
	    private IUserNotification _userNotification;
	    public UserService(IUserRepository userRepository)
	    {
	        _userRepository = userRepository;
    	    _userNotification = userNotification;	
    	}
        public void NotifyInactiveUsers(DateTime activeBefore)
        {
            var users = _userRepository.GetAllUsers();
	        foreach(var user in users)
	        {
		        if(user.LastActivityDate > DateTime.Now)
		        {
		            _userNotification.SendRemovalNotification(user)
		            _userRepository.MarkUserForRemoval(user)
		        }
    	    }
        }
    }

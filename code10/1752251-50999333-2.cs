    public class UsersController
	{
		UsersDbServices m_UsersDbServices = new UsersDbServices ();
		
		[HttpGet]
		public UserDTO GetUserById(userId)
		{
			UserDTO retVal = null;
		
			UserDbEntity userDbEntity  = m_UsersDbServices.GetUserById(userId);
			if(userDbEntity == null){
				throw...
			}
			
			retVal = new UserDTO()
			{
				FirstName  = userDbEntity.FirstName;
				...
			};
			
			if(!UserIsAdmin) <- kept it as a bool here
			{	
				retVal.Address  = null;
			}
			
			return retVal; <- convert to json
		}
	}

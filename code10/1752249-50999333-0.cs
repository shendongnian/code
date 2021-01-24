    public class UsersDbServices 
	{
		public UserDbEntity GetUserById(int userId)
		{
			UserDbEntity user = null
			using (context..)
			{
				user = context.Users.Where(u=> u.Id = userId).FirstOfDefault();
			}
			
			return user;
		}
	}

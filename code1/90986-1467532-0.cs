	public class User { public Guid Id { get; set; } }
	public class UserProfile : User { public string Url { get; set; } }
	class MyReader
	{
		private T LoadUser<T>(IDataReader reader)
			where T : User, new()
		{
			T user = new T();
			user.Id = reader.GetGuid(reader.GetOrdinal("userID"));
			return user;
		}
		public UserProfile LoadUserProfile(IDataReader reader)
		{
			UserProfile profile = LoadUser<UserProfile>(reader);
			profile.Url = (string)reader["url"];
			return profile;
		}
	}

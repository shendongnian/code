	public class InitUser
	{
		public InitUser(SqlDataReader dr, User u) { }
	}
	public class InitUserExtension : InitUser
	{
		public InitUserExtension(SqlDataReader dr , UserExtension u) : base(dr, u) { }
	}

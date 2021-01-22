	public class UserParameter : IParameter<User>
	{
		public void Populate(SqlParameterCollection parameters, User entity)
		{
			parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = entity.Id;
			parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = entity.Name;
			parameters.Add("@EmailAddress", SqlDbType.NVarChar, 255).Value = entity.EmailAddress;
		}
	}

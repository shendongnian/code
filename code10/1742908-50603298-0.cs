	public interface IUserDto
	{
		int UserID { get; set; }
		string UserName { get; set; }
	}
	public class UserDto : IUserDto { ... }
	public IQueryable<TUserDto> GetUsers<TUserDto>()
		where TUserDto : class, IUserDto, new()
	{
		// ...
			new TUserDto
			{
				UserID = u.ID,
				UserName = u.Name
			}
		// ...
	}

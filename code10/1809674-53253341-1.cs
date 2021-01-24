    var users = new List<User>
	{
		new User { Id = 1, UserName = "User1", UserTypeId = 1 }, 
		new User { Id = 2, UserName = "User2", UserTypeId = 2 }, 
		new User { Id = 3, UserName = "User3", UserTypeId = 2 }, 
	};
	
	var userTypes = new List<UserType>
	{
		new UserType { Id = 1, Type = "Admin", Security = 1 }, 
		new UserType { Id = 2, Type = "User", Security = 2  }
	};
	
	var userId = 1;
	
	var ViewerUserID = 2;
	var viewerSecurity = 
		(from u in users
		join ut in userTypes on u.UserTypeId equals ut.Id
		where u.Id == ViewerUserID
		select ut.Security).FirstOrDefault();
	
	var res = 
		(from u in users
		join ut in userTypes on u.UserTypeId equals ut.Id
		where u.Id == userId || u.Id == -1
		select new
		{
			Id = u.Id,
			UserName = u.UserName,
			CanEdit = viewerSecurity > ut.Security ? 1 : 0
		});
    }
    
    class User {
    	public int Id {get; set;}
    	public string UserName {get; set;}
    	public int UserTypeId {get; set;}
    }
    
    class UserType {
    	public int Id {get; set;}
    	public string Type {get; set;}
    	public int Security {get; set;}
    }

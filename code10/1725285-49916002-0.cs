    class GroupUsers 
    {
    	public int GroupId {get;set;}
    	public int UserId {get;set;}
    }
    
    public class Program
    {
    	public static void Main()
    	{
        var groupUsers = new List<GroupUsers>() { 
        new GroupUsers{ GroupId = 1, UserId = 1},
        new GroupUsers{ GroupId = 1, UserId = 1},
        new GroupUsers{ GroupId = 1, UserId = 2},
    	new GroupUsers{ GroupId = 1, UserId = 2},
    	new GroupUsers{ GroupId = 1, UserId = 3},
    	new GroupUsers{ GroupId = 1, UserId = 4},
    	new GroupUsers{ GroupId = 1, UserId = 5},
    	new GroupUsers{ GroupId = 1, UserId = 3}
        };
    
         var result1 =  groupUsers
                        .GroupBy(u => new { u.GroupId, u.UserId} )
                        .Where(g => g.Count()>=2) // check for duplicate value by checking whether the count is greater than or equal to 2.
                        .SelectMany(g=>g); // flatten the list
    
        foreach(var user in result1) // Iterate over the result
    	{
    	    Console.WriteLine(user.GroupId +" "+user.UserId);
    	}
        // Or
    	var result2 =   from a in groupUsers
    		            group a by new{a.GroupId, a.UserId} into grp
    		            where grp.Count()>=2
    		            from g in grp select new{g}
    
        foreach(var user in result2)
    	{
    	    Console.WriteLine(user.g.GroupId +" "+user.g.UserId);
    	}
    
    	}
    }

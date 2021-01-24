    /// <summary>
    ///     Assuming this is the EF model, generated with the database first approach. We leave it as is.
    /// </summary>
    public class UserEntityModel
    {
    	public int Id { get; set; }
        
    	public string UserName { get; set; } 
        
    	public string FirstName { get; set; }
        
    	public string LastName { get; set; }
        
    	public int UserType { get; set; }
    }
        
    /// <summary>
    ///     This model represents your grid presentation specific data. As you can see, we have the fields 
    ///     that we will show. This is the new DTO model
    /// </summary>
    public class UserGridViewModel
    {
    	public string UserName { get; set; }
        
    	public string FullName { get; set; } 
        
    	public int UserType { get; set; }
    }
    
    /// <summary>
    ///     This method demonstrates the retrieving and model to model mapping.
    /// </summary> 
    public UserGridViewModel GetUser(int userId)
    {
    	  //retrieve the UserEntityModel
          var efObject = _context.User.Where(user => user.Id == userId).SingleOrDefault();
     
           if (efObject  == null) {
              return null;
           }
    	   
    	   // construct the new object, set the required data 
           return new UserGridViewModel()
           {
                UserName = efObject.UserName,
                UserType = efObject.UserType,
                FullName = $"{efObject.FirstName} {efObject.LastName}"
    		};
    }

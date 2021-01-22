    public class ClassThatNeedsUserDAO
    {
         private readonly IUserDAO _userDAO;
         public ClassThatNeedsUserDAO(IUserDAO userDAO)
         {
             _userDAO = userDAO;
         }
    
         public User MyMethod(userId)
         {
             return _userDAO.GetById(int userId);
         }     
    }

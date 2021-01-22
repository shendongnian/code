    // Level 0 (Root Base Class)     
    public abstract class BusinessDataControllerBase<BDA> : IBusinessDataController 
    {
       protected BDA da;
    
       public BusinessDataControllerBase()
       {
          // Initialize the respective Data Access Layer passed by the concrete class
          this.da = new BDA();
       } 
    }        
            
    // Level 1 (Second Level Base Class) public abstract class 
    BusinessRootDataControllerBase<BDA> : BusinessDataControllerBase<BDA>, IBusinessRootDataController
                        where BDA : IBusinessDALController, new() 
    { 
       public BusinessRootDataControllerBase()
          : base() {}     
    }
                
    // Level 2 (Third Level Base Class) public abstract class BusinessMasterRootDataControllerBase<BRC, BRD, BDA> : BusinessRootDataControllerBase<BDA>, IDisposable
          where BRC : IBusinessRootDataController 
          where BRD : IBusinessRootData
          where BDA : IBusinessDALController, new() 
    { 
       public BusinessMasterRootDataControllerBase()
          : base() {} 
    }
          
    // Level 3 (Concrete Class) public class UserController : BusinessMasterRootDataControllerBase<UserController, UserData, UsersDAL> 
    {
       # region Singleton implementation - Private Constructor, Static initialization
       private static readonly UserController instance = new UserController();
                    
       public static UserController Instance
       {
          get { return instance; }
       }
       # endregion
            
       # region Constructor
       // --------------------------------------------------------------------------------
       //Private Constuctor
       private UserController()
          : base()
       {
       }
       // --------------------------------------------------------------------------------
            
       private void DoLogin(string userName, string password)
       {
          DataSet dstUser = da.GetUser(userName);
          // Check user name
          // Check password
       } 
    }

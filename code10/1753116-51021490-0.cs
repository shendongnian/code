    public class CustomController:BaseController /*Maybe you dont need BaseController anymore if it only provides you dependencies*/
    {  
        protected UserManager UserManager{get;set;}
        protected AuditManager AuditManager {get;set;}
       public CustomController(IAuditManager auditManager,UserManager userManager)
       {
           this.UserManager=userManager;
           this.AuditManager=auditManager;
       }
    }
    //Unit test
    [Test]
    public void CustomController_WithMockedUserManager_IsAbleToTest()
    {
          CustomController = new CustomController( yourMockedUserManager, yourMockedAuditManager);
         //Asserts...etc
    
    }

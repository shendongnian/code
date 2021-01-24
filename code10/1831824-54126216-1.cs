    public static string UserAdminControllerPrefix = "/Users";
    UserAdminController : AdminBaseController { 
    [Route(UserAdminControllerPrefix + "/ActionName")]
    public void ActionName() {  }
    }

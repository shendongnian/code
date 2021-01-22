    class ApplicationFacade{
      private IUserRepository users = null;
     
      public doStuff(){
        this.users.GetUser("my-name");
      }
    }

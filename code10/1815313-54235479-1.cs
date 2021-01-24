    class MainViewModel
    {
    
      public MainViewModel()
      {
        AuthorizeCommand = new Command<string>(CmdAuthorize);
      }
    
      public ICommand AuthorizeCommand{get;set;}
      public List<User> Users{get;set;}
    
      CmdAuthorize(string id)
      {
        var user = Users.First(x=>x.Id == id);
        user.IsAuthorized = true;
      }
    }

    public class UserClass
    {
      public string Edit {get;set;}
      public string Add {get;set;}
    }
    
    public class UrlsClass
    {
      public UserClass User {get;set;}
    }
    
    public class Website
    {
      public UrlsClass Urls {get;set;}
    }

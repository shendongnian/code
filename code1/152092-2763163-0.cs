    public abstract class BaseViewModel
    {
      public string SiteTitle {get;set;}
      public int SomeProperty{get;set;}
    }
    
    public class UserViewModel: BaseViewModel
    {
      public string UserName{get;set;}
      public string Email{get;set;}
    }

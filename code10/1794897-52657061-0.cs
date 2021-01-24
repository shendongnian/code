    //Entity
    public class User
    {
       public int ID {get;set;}
       public string Name {get;set;}
       public int firstName{get;set;}
       public date dateofBrith {get;set;}
       public string password {get;set;}
       public string email {get;set;}
       public string address {get;set;}
    }
    
    // View Models...
    public class LiteUserViewModel 
    {
       public int ID {get;set;}
       public string Name {get;set;}
       public int firstName{get;set;}
    } 
    
    public class FullUserViewModel : LiteUserViewModel
    {   
       public date dateofBrith {get;set;}
       public string password {get;set;}
       public string email {get;set;}
       public string address {get;set;}
    } 

    [Table("user")]
    public class LiteUser 
    {
       public string Name {get;set;}
       public int firstName{get;set;}
    }
    public class fullUser : LiteUser
    {   
       public int ID {get;set;}
       public date dateofBrith {get;set;}
       public string password {get;set;}
       public string email {get;set;}
       public string address {get;set;}
    }

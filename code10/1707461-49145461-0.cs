    public class Sector
    {
       public int ID {get; set;}
       public string Sector_name {get; set;}
       public int UserId {get; set;}
       // you can't use Users class for navigation purpose because Users is in different context
    }

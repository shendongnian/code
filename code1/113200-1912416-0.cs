    public class Entity<TKey>
    {
       public TKey ID {get;set;}
    }
    
    public class Person: Entity<int>
    {
       public string Firstname {get;set;}
       public string Surname {get;set;}
    }

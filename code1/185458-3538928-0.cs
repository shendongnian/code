    public abstract class Entity
    {
         public int Id { get; set;}
         
         public bool IsNew { get { return Id == 0; } }
         public abstract DoSomething(int id); // must be implemented by concrete class
    }

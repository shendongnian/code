    public interface IUpdatable
    {
         bool IsUpdated { get; set; }
    }
    public interface IManyUpdatable 
    {
         IEnumerable<IUpdatable> Updatables { get; }
    }
    public static class UpdatableExtensions 
    {
         public static void ToggleUpdated(this IUpdatable updatable) 
         {
              if(updatable != null)
                   updatable.IsUpdated = !updatable.IsUpdated
         }
         public static void ToggleUpdatables(this IEnumerable<IUpdatable> updatables)
         {
              foreach(var updatable in updatables) 
                     updatable.ToggleUpdated()
             
         }
    }
    public class Foo<T> : IUpdatable
    {
       public bool IsUpdated { get; set; }
    }
    public class ItemList: ValueObject<ItemList>
    {
       public Foo<string> FirstName;
    
       public Foo<string> LastName;
       IEnumerable<IUpdatable> IManyUpdatable.Updatables => new [] {  FirstName, LastName }
    }
    // ... somewhere in your code base:
    itemList.ToggleUpdatables()

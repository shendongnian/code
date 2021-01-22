    public class SomeNiceObject : ObjectBase
    {
      public string Field1{ get; set; }
    }
    public interface IFromDatabase
    {
      bool ReadAllFromDatabase();
    }
    public class CollectionBase<ObjectBase>() : IFromDatabase
    {
      public bool ReadAllFromDatabase();
    }
    
    public class SomeNiceObjectCollection : CollectionBase<SomeNiceObject>
    {
    
    }
    public class DAL
    {
    
     public SomeNiceObjectCollection Read()
     {
      return ReadFromDB<SomeNiceObjectCollection>();
     }
    
     T ReadFromDB<T>() where T : IFromDatabase, new()
     {
      T col = new T();
      col.ReadAllFromDatabase();
      return col;          
     }
    }

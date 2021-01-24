    public class DaCollectionOfInt<T>
    {
         public int id { get; set; }
    }
    
    var result = from m in list select new DaCollectionOfInt<int>() { id = m.id };

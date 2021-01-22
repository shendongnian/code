    public class BaseRecord {  
      public bool isDirty;  
      public IList<dynamic> items;  
      public dynamic this[int index]
      {
         get { return items[index];}
         set { items[index] = value;}
      }
      public ReadOnlyCollection<string> columnNames;    
    }

    public class BaseRecord {  
      public bool isDirty;  
      public IList<Object> items;  
      public Object this[int index]
      {
         get { return items[index];}
         set { items[index] = value;}
      }
      public ReadonlyCollection<string> columnNames;    
    }

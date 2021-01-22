    public class MyClass
    {
       DataTable myRow = null;
       MyClass(DataRow row)
       {
          myRow = row;
       }
    
       public object this[string name]
       {
          get
          {
             return this.myRow[name];
          }
          set
          {
             this.myRow[name] = value;
          }
       }
    }

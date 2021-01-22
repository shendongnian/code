    public class Table
    {
      public static readonly Company = new Table("T_Company");
      public static readonly Title = new Table("T_Title");
      public static readonly City = new Table("T_City");
    
      private string name;
      public string Name { get { return name; } }
      
      private Table(string name)
      {
        this.name = name;
      }
    }
    
    class b 
    {
        // ...
    
        // use it like this:
        ds.Tables[Table.Company.Name];
    }

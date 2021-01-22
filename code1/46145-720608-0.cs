    public interface ITable
    {
        string Name { get; }
    }
    
    internal interface ITableInternal
    {
       void SetName(string value);
    }
    
    public class Table : ITable, ITableInternal
    {
        public string Name { get; }
    
        public void SetName(string value)
        {
           // Input validation
    
           this.Name = value;
        }
    }
    
    public class Database
    {
        public Table CreateTable()
        {
            Table instance = new Table();
            ((ITableInternal)instance).SetName("tableName");
    
            return table;
        }    
    }

    public interface ITable
    {
       string Name { get; }
    }
    internal interface IInternalTable 
    {
       string Name { get; set; }
    }
    public class Table : ITable, IInternalTable
    {
       public string Name { get; set; }
       string ITable.Name { get { return Name; } }
    }
    public class Database
    {
        private List<Table> tables;
        public List<Table> Tables
        {
           get { return this.tables; }
        }
    }

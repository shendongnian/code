    public interface ITable
    {
       string Name { get; }
    }
         
    public class Database
    {
        private interface IInternalTable 
        {
           string Name { get; set; }
        }
        private class Table : ITable, IInternalTable
        {
            public string Name { get; set; }
            string ITable.Name { get { return Name; } }
        }
        private List<IInternalTable> tables;
    
        public List<ITable> Tables
        {
           get { return this.tables; }
        }
    }

    public interface ITable
    {
        string Name { get; }
    }
    public class Table : ITable
    {
        public string Name { get; internal set; }
    }
    public class Database
    {
        public List<ITable> Tables { get; internal set; }
    }

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
        public string Name { get; internal set; }
        string IInternalTable.Name { get { return Name; } set { Name = value; } }
    }

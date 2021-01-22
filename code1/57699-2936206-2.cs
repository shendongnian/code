    public interface IDataContext
    {
        void Save(string fromHandler);
    }
    class DataContext : IDataContext
    {
        private readonly Guid _guid;
        public DataContext()
        {
            _guid = Guid.NewGuid();
        }
        public void Save(string fromHandler)
        {
            Console.Out.WriteLine("GUI: [{0}] {1}", _guid, fromHandler);
        }
    }

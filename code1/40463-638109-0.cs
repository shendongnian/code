    public class RepositoryBase<T> where T : class, Interfaces.IModel
    {
        public DataContext _db;
    
        public List<T> GetItems()
        {
            var table = _db.GetTable<T>();
            var data = table.Where(t => !t.Deleted);
    
            return data.ToList();
        }
    }

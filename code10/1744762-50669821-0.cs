    public class MyBaseEntity
    {
        public int Id { get; set; }
    }
    
    public class MyTable : MyBaseEntity
    {
        public string MyProperty { get; set; }
    }
    
    public static class RepositoryExtensions
    {
        public static IQueryable<T> FindMacthes<T>(this DbContext db, IEnumerable<int> keys)
            where T : MyBaseEntity
            => db.Set<T>().Where(x => keys.Contains(x.Id));
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize your own DbContext.
            var db = new DbContext(null);
            // Usage:
            var lookupKeys = new[] { 1, 2, 3 };
            var results = db.FindMacthes<MyTable>(lookupKeys).ToList();
        }
    }

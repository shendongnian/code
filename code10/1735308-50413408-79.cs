    public class DatastoreSportsStore : ISportsStore {
        string kind = "Sports_db";
        private readonly DatastoreDb _db;
        
        public DatastoreSportsStore() {
            _db = DatastoreDb.Create("projectid");
        }
        public void Create(Item item) {
            var entity = item.ToEntity();
            entity.Key = _db.CreateKeyFactory(kind).CreateIncompleteKey();
            var keys = _db.Insert(new[] { entity });
            item.Id = keys.First().ToId();
        }
        
        public Item Read(string id) {
            return _db.Lookup(id.ToKey())?.ToItem();
        }
        
        public List<Item> ReadAll() {
            var query = new Query(kind);
            var results = _db.RunQuery(query);
            return results.Entities.Select(entity => entity.ToItem()).ToList();
        }
        
        public void Update(Item item) {
            _db.Update(item.ToEntity());
        }
        
        public void Delete(string id) {
            _db.Delete(id.ToKey());
        }
    }

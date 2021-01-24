    public class Repository<T> : IRepository<T> where T : Entity, new() {
    
        public Repository(ISQLiteAsyncProvider provider) {
            this.connection = new LazyAsync<SQLiteAsyncConnection>(await () => {
                var db = provider.GetConnection();
                await db.CreateTableAsync<T>();
                return db;
            });
        }
        private readonly LazyAsync<SQLiteAsyncConnection> connection;
        
        public async Task<List<T>> Get() {
            var _db = await connection.Value;
            return await _db.Table<T>().ToListAsync();
        }
        public async Task<T> Get(int id) {
            var _db = await connection.Value;
            return await _db.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<int> Save(T entity) {
            var _db = await connection.Value;
            return entity.Id == 0 
                ? await _db.InsertAsync(entity) 
                : await_db.UpdateAsync(entity);
        }
        public async Task<int> Delete(T entity) {
            var _db = await connection.Value;
            return await _db.DeleteAsync(entity);
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                // get rid of managed resources
            }
            // get rid of unmanaged resources
        }
    }
    

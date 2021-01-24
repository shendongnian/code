    public class Repository<T> : IRepository<T> where T : Entity, new() {
         private readonly SQLiteAsyncConnection _db;
    
        public Repository(string dbPath) {
            _db = new SQLiteAsyncConnection(dbPath);
            createTable += onCreateTable; //Subscribe to event
            createTable(this, EventArgs.Empty); //Raise event
        }
    
        private event EventHandler createTable = delegate { };
        private async void onCreateTable(object sender, EventArgs args) {
            createTable -= onCreateTable; //Unsubscribe from event
            await _db.CreateTableAsync<T>(); //async non blocking call
        }
    
        //...
    }

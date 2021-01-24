    public interface IAppDatabase {
        // These members just for example. Maybe instead of something general like
        // `GetAllNames()` we have operations specific to app operations such as
        // `UpdateAddress(Guid id, Address newAddress)`, `GetNameFor(SomeParams p)` etc.
        Task<List<Name>> GetAllNames();
        Task<Address> LookupAddress(Guid id);
    }
    public class AppDatabase : IAppDatabase {
        // ...
        public AppDatabase(IInventoryDatabase db) { ... }
        public Task<List<Name>> GetAllNames() {
            // use `db` and Entity Framework to retrieve data...
        }
        // ...
    }

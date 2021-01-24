c#
/// ============ Main Project or Base Class Library =============
public class SomeController<TId> : Controller
{
    private readonly IRepository<TId> db;
    public SomeController(IRepository<TId> db)
    {
        this.db = db;
    }
    public async Task<IAsyncResult> Get(TId id)
    {
        return await db.FindAsync(id);
    }
}
/// =========== New Assembly ============
public class SomeController : SomeController<int>
{
    public SomeController(IRepository<int> db) : base(db) { }
}
All that's left to do when changing the database implementation is to implement the generic repository, inherit the generic controller, and replace the reference of the implementing assembly in the main project!
Ta Daaa!! :)
I love .NET...

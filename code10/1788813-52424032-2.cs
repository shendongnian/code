public class Db : IDb
{
    private readonly Func<SqlConnection> _dbConnectionFactory;
    public Db(Func<SqlConnection> dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
    }
    public async Task<T> CommandAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<T>> command)
    {
        using (var connection = _dbConnectionFactory.Invoke())
        {
            await connection.OpenAsync();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var result = await command(connection, transaction, Constants.CommandTimeout);
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Logger.Instance.Error(ex);
                    throw;
                }
            }
        }
    }
    public async Task<T> GetAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<T>> command)
    {
        return await CommandAsync(command);
    }
    public async Task<IList<T>> SelectAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<IList<T>>> command)
    {
        return await CommandAsync(command);
    }
    public async Task ExecuteAsync(string sql, object parameters)
    {
        await CommandAsync(async (conn, trn, timeout) =>
        {
            await conn.ExecuteAsync(sql, parameters, trn, timeout);
                return 1;
        });
    public async Task<T> GetAsync<T>(string sql, object parameters)
    {
        return await CommandAsync(async (conn, trn, timeout) =>
        {
            T result = await conn.QuerySingleAsync<T>(sql, parameters, trn, timeout);
            return result;
        });
    }
    public async Task<IList<T>> SelectAsync<T>(string sql, object parameters)
    {
        return await CommandAsync<IList<T>>(async (conn, trn, timeout) =>
        {
            var result = (await conn.QueryAsync<T>(sql, parameters, trn, timeout)).ToList();
            return result;
        });
    }
}
_Repository_ class:
public class Repository<Entity> : IRepository<Entity>
{
    protected readonly IDb _db;
    public Repository(IDb db)
    {
        _db = db ?? throw new
            ArgumentException(nameof(db));
    }
    public async Task Add(Entity entity)
    {
        await _db.ExecuteAsync("INSERT INTO ... VALUES...", entity);
    }
    public async Task Update(Entity entity)
    {
        await _db.ExecuteAsync("UPDATE ... SET ...", entity);
    }
    public async Task Remove(Entity entity)
    {
        await _db.ExecuteAsync("DELETE FROM ... WHERE ...", entity);
    }
    public async Task<Entity> FindByID(int id)
    {
        return await _db.GetAsync<Entity>("SELECT ... FROM ... WHERE Id = @id", new { id });
    }
    public async Task<IEnumerable<Entity>> FindAll()
    {
        return await _db.SelectAsync<Entity>("SELECT ... FROM ... ", new { });
    }
}
`Db` can be extended with other generic method, for example, `ExecuteScalar`, which you would need in your repositories. Hope it helps.

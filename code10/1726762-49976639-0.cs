    public class Test<T> where T : class, UnicontaBaseEntity, new()
    {
        private async Task FooAsync(QueryAPI queryAPI, CrudAPI crudAPI, SyncSettings syncSettings)
        {
            Task<T[]> result = await queryAPI.QueryAsync<T>();
        }
    }
    
    public interface UnicontaBaseEntity : UnicontaStreamableEntity
    {
        int CompanyId { get; }
    
        Type BaseEntityType();
    }
    
    
    public class QueryAPI : BaseAPI
    {
        ...
        public Task<T[]> QueryAsync<T>() where T : class, UnicontaBaseEntity, new()
        ...
    }

    public class DataAccess<TModel>
    {
        public async Task<TModel> GetItemFromServerAsync(string id)
        {
            return default(TModel); // just to make it compile, I assume you do some data access here or something
        }
    }

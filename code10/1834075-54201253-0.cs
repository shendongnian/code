    public abstract class BaseHandler
    {
        protected virtual Task<string> GetEntityName(object entity)
        {
            return Task.FromResult(string.Empty);
        }
    }

    public sealed class UnitOfWorkScope<T> : IDisposable
        where T : ObjectContext, IDisposable, new()
    {
        public void Dispose()
        {
            // I assume you'll want to call IDisposable on your T here...
        }
    }

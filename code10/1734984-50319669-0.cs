    public interface IMyDbContext
    {
        void BulkInsert<T>(IList<T> entities, BulkConfig bulkConfig = null,
            Action<decimal> progress = null) where T : class;
    
    }
    
    public class MyDbContext : DbContext, IMyDbContext
    {
        public void BulkInsert<T>(IList<T> entities, BulkConfig bulkConfig = null,
            Action<decimal> progress = null) where T : class
        {
            this.BulkInsertOrUpdate(entities, bulkConfig, progress);
        }
    }

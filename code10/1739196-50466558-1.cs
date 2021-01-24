    public abstract class MockDataStoreBase<T> : IDataStore<T> where T : BaseEntity
    {
        protected List<T> items = new List<T>();
    
        public virtual async Task<bool> AddAsync(T item)
        {           
        }
    
        public async Task<bool> UpdateAsync(T item)
        {           
        }
    
        public async Task<bool> DeleteAsync(T item)
        {           
        }
    }
    public class EntityADataStore : MockDataStoreBase<EntityA>
    {
        public override async Task<bool> AddAsync(EntityA item)
        {
            bool result = await base.AddAsync(item);
        }
        //...
    }

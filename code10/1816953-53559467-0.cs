        public interface IEntity
        {
            int Id { get; }
        }
    Meaning your entities will look something like this:
        public class SomeEntity : IEntity
        {
            public int Id { get; set; }
        }
    And finally your method now looks a lot simpler:
    
        protected async Task<ResultModel<TU>> GetEntityByIdAsync<TU, TKey>(TKey id)
            where TU : IEntity
        {
            return await _db.Set<TU>.FirstOrDefaultAsync(x => x.Id == id);
        }

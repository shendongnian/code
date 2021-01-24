    public class ParamRepository : IParamRepository
    {
        private readonly DbContextOptions<MyContext> _dbContextOptions;
    
        public ParamRepository(DbContextOptions<MyContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
    
        public async Task<(int id, string name)> GetParamsByCode<TEntity>(string code) where TEntity : class
        {
            string entityName = typeof(TEntity).Name;
            string idProp = $"Id{entityName}";
            string nameProp = $"{entityName}Name";
            try
            {
                using (var db = new MyContext(_dbContextOptions))
                {
                  var entity = await db.Set<TEntity>().AsNoTracking()
                            .Where(p => EF.Property<string>(p, "Code") == code)
                            .Select(p => new { Id = EF.Property<int>(p, idProp), Name = EF.Property<string>(p, nameProp)})
                            .FirstAsync();
    
                  return (id: entity.Id, name: entity.Name);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error on getting entity by code: {code}");
            }
        }
    }

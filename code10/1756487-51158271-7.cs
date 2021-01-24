    public abstract class BaseOMSService<TEntity> : IOMSService<TEntity>
        where TEntity : class
    {
        private MyDBContext _context;
        private IMapper _mapper;
    
        public BaseOMSService(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        public IEnumerable<TModel> Get<TModel>(
                Expression<Func<TEntity, bool>> predicate, 
                params Expression<Func<TEntity, object>>[] includes) 
        {
        	var result = _context.Set<TEntity>()
        		.Where(predicate);
        
            if(includes != null)
            {
            	foreach (var include in includes)
            	{
            		result = result.Include(include);
            	}
            }
        
        	return _mapper.Map<IList<TModel>>(result);
        }
    }

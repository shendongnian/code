    public class FunkyController : Controller
    {
        private readonly NavigationContext _nagivationContext;
    
        public FunkyController(NagivationContext nagivationContext)
        {
            //Context is injected into the constructor of the controller
            _nagivationContext = nagivationContext;
        }
    
        public int Add(TEntity item)
        {
            _nagivationContext.Set<TEntity>().Add(item);
            _nagivationContext.SaveChanges();
            return item.Id;
        }
    }

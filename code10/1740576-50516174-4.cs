    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public HomeController(AppDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var categoryTranslations = _dbContext.CategoryTranslations
                .AsNoTracking()
                .Include(ct => ct.Category)
                .Include(ct => ct.Language)
                .Where(ct => ct.Language.Code == "en-US")
                .ToList();
            var categoryOutputModels = categoryTranslations
                .GroupBy(ct => ct.Category, (key, group) => 
                    // Use this map overload to map the category entity
                    // to a new CategoryOutputModel object
                    _mapper.Map<Category, CategoryOutputModel>(key));
            return View();
        }
    }

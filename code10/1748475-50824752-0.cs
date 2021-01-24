    public class MyClass : IMyClass {
    
        private readonly ApplicationDbContext _dbContext;
        private readonly ICalendarService _calendarService;
    
        public MyClass(ApplicationDbContext dbContext, ICalendarService calendarService)
        {
            _dbContext = dbContext;
            _calendarService = calendarService;
        }
    
        public void MyFunction()
        {
            // here I need to use _dbContext and _calendarService
        }
     }

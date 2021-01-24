    public class HomeController : Controller
    {
        private readonly IWordService _wordService;
        public HomeController(IWordService wordService)
        {
            _wordService = wordService;
        }
        [HttpPost]
        public IActionResult Index(WordGameModel incomingModel)
        {
            if (ModelState.IsValid)
            {
                // Use the `_wordService instance to perform your checks and validation
                ...
            }
            ...
        }
    }

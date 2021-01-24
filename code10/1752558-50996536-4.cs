    public class MyController : Controller
    {
        private readonly IToDoContext _db;
        public MyController(IToDoContext db)
        {
            _db = db;
        }
        
        public async Task<IActionResult> IndexVC("PriorityList", new { maxPriority, isDone = false })
            {
                if (string.IsNullOrWhiteSpace(maxPriority))
                    return BadRequest($"maxPriority cannot be empty");
    
                var model = await InvokeAsync(maxPriority, isDone);
                
                if (model == null)
                {
                    return BadRequest($"model not found");
                }
    
                return View(model);
            }
            
        public async Task<IViewComponentResult> InvokeAsync(
            int maxPriority, bool isDone)
            {
                var items = await GetItemsAsync(maxPriority, isDone);
                return View(items);
            }
            private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
            {
                return _db.ToDo.Where(x => x.IsDone == isDone &&
                                     x.Priority <= maxPriority).ToListAsync();
            }
    }

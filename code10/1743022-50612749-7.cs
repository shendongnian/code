    public ClassAController : AdminControllerBase
    {
        private readonly AppDbContext _dbContext;
        public ClassAController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Edit(int id)
        {
            // Find the entity by id in the database
            var classAEntity = _dbContext.ClassAs
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);
            if (classAEntity == null)
            {
                return NotFound();
            }
            // Find a list of available class Bs
            var availableClassBs = _dbContext.ClassBs
                .AsNoTracking()
                .Where(x => ... your filter ...)
                .OrderBy(x => x.Name)
                .ToDictionary(x => x.Id, x => x.Name);
            // Construct the view model for editing
            var vm = new EditClassAViewModel
            {
                ClassAId = classAEntity.Id,
                Name = classAEntity.Name,
                SelectedClassBId = classAEntity.ClassBId,
                AvailableClassBs = availableClassBs
            };
            return View(vm);
        }
    }

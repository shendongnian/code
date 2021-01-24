    public async Task<IActionResult> Create(CategoriesViewModelIEnumerable model)
    {
        if (ModelState.IsValid)
        {
        model.competition.CompetitionCategories = new Collection<CompetitionCategory>();
            foreach (var CategoryName in model.SelectedCategories)
            {
                 model.competition.CompetitionCategories.Add(new CompetitionCategory { CompetitionID=model.competition.ID, CategoryName=CategoryName});
            }
            _context.Add(model.competition);
            await _context.SaveChangesAsync();
        }
    }

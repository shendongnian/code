    MonthRepository monthRepository = new MonthRepository();
    IQueryable<MonthEntity> entities = monthRepository.GetAllMonth();
    List<MonthEntity> monthEntities = new List<MonthEntity>();
    
    foreach(var r in entities)
    {
        monthEntities.Add(r);
    }
    
    ViewData["Month"] = new SelectList(monthEntities, "MonthID", "Month", "Mars");

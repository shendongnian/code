    TipoProyectoViewModel viewModel = new TipoProyectoViewModel();
    
    var catgoryGroup = _dbContext.Categoria
        .Include( c => c.TipoProyecto )
        .Where( c => c.CategoryId == CategoryId )
        .GroupBy( e => e.CategoryName )
        .FirstOrDefault();
    viewModel.Category = catgoryGroup.Key;
    viewModel.Tipo = categoryGroup
        .SelectMany( p => p.ProjectType )
        .ToList(); // Always call ToList() because you should never pass an IQueryable to your View!
    viewModel.Glyphicons = _dbContext
        .Select( /* your query to get data for this property */ );

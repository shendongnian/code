    var results = dbContext.Categories
        .Where(category => ...)
        .Select(category => new
        {
             // only select properties that you plan to use
             Id = category.Id,
             Name = category.Name,
             ...
             Todos = category.Todos
                 .Where(todo => ...)        // only if you don't want all Todos
                 .Select(todo => new
                 {
                     // again, select only the properties you'll plan to use
                     Id = todo.Id,
                     ...
                     // not needed, you know the value: CategoryId = todo.CategoryId
                     // only if you also want some infos:
                     Infos = todo.Infos
                        .Select(info => ....) // you know the drill by now
                        .ToList(),
                })
                .ToList(),
            });

    _context.RecipeIngredients
        .Where( rI => ingredients.Contains( rI.IngredientId ) )
        .GroupBy( rI => rI.Recipe )
        .Select( g => new
        {
            Recipe = g.Key,
            MatchingIngredientCount = (double)g.Count() / (double)g.Key.RecipeIngredients.Count(),
            g.Key.ComplexityTag,
            g.Key.TypeTag,
            g.Key.RecipeIngredients,
            // this eager-loads the `Ingredient` entities
            //   EF will automatically wire them up to the `RecipeIngredient` entities
            //   if tracking is enabled
            Ingredients = g.Key.RecipeIngredients.Select( ri => ri.Ingredient ),
        } )
        .OrderByDescending(r => r.MatchingIngredients)
        .Take(MaxAmountBestRecipes)
        .ToArray()
        .Select( a = new ...
        {
            ...
            IngredientAmount = a.RecipeIngredients.ToDictionary(
                ri => ri.Ingredient.Name, // ri.Ingredient should now not be NULL
                ri => ri.Quantity )
        } );

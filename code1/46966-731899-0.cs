    List<string> ingredientNames = ingredientsList
      .Select( i => i.Name).ToList();
    Dictionary<string, Double> ingredientValues = ingredientsList
      .ToDictionary(i => i.Name, i => i.Amount);
    //database hit
    List<Ingredient> queryResults = db.Ingredients
      .Where(i => ingredientNames.Contains(i.Name))
      .ToList();
    //continue filtering locally - TODO: handle case-sensitivity
    List<Ingredient> filteredResults = queryResults
      .Where(i => i.Amount <= ingredientValues[i.Name])
      .ToList();

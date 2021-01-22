    public IEnumerable<Tuple<string,int>> ListIngredients()
    {
        return RecipeIngredients.Select(i => Tuple.Create(i.Ingredient.Name,
                                                          i.Quantity));
    }

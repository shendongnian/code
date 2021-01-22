    private static bool IsIngredientPresent(IngredientBag i, string ingredientType, string ingredient)
    {
        return i != null && i.Contains(ingredientType) && i.Get(ingredientType).Contains(ingredient);
    }
    public static Expression<Func<Potion, bool>>
					ContainsIngredients(string ingredientType, params string[] ingredients)
    {
        var predicate = PredicateBuilder.False<Potion>();
        // Here, I'm accessing p.Ingredients several times in one 
        // expression.  Is there any way to cache this value and
        // reference the cached value in the expression?
        foreach (var ingredient in ingredients)
        {
            var temp = ingredient;
            predicate = predicate.Or(
                p => IsIngredientPresent(p.Ingredients, ingredientType, temp));
        }
        return predicate;
    }

    private static bool TestWith<T>(T cached, Func<T, bool> predicate)
    {
        return predicate(cached);
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
            predicate = predicate.Or (
                p => TestWith(p.Ingredients,
                    i => i != null &&
                         i.Contains(ingredientType) &&
                         i.Get(ingredientType).Contains(temp));
        }
        return predicate;
    }

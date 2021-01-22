    public List<Recipe> GetRecipesWhichHaveGivenIngredients(HashSet<Ingredient> ingredients)
    {
       using (DataContext context = new DataContext())
       {
           return context.Recipes
               .Where(x => ingredients.IsProperSubsetOf(x.IngredientList)  
               .ToList();
       }
     }

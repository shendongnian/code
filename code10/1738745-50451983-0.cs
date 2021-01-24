        List<Recipe> L_Recipes = new List<Recipe>();
        Cook Cook = dbc.DbCook.Include(c => c.ListRecipes).singleOrDefault(c => c.Nickname == cook.Nickname);
        L_Recipes = Cook.ListRecipes;
        return L_Recipes;
    }`

    var recipe = new Recipe { Name = "Dough" };
    var ingredients = new []
    { 
       new Ingredient { Name = "water", Unit = "cups", Amount = 2.0 }, 
       new Ingredient { Name = "flour", Unit = "cups", Amount = 6.0 }, 
       new Ingredient { Name = "salt", Unit = "teaspoon", Amount = 2.0 }
    };
    
    foreach (var ingredient in ingredients)
    {
       var relation = new IngredientsRecipesRelations();
       relation.Ingredient = ingredient;
       recipe.IngredientsRecipesRelations.Add(relation);
    }
    
    DataContext.Recipes.InsertOnSubmit(recipe);
    DataContext.SubmitChanges();

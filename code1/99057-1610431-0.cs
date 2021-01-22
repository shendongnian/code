    var mocks = new MockRepository();
    var repository = mocks.StrictMock<IRecipeRepository>();
    IList<Recipe> recipes = new List<Recipe>();
    recipes.Add(new Recipe { ID = 1, Name = "Fish" });
    recipes.Add(new Recipe { ID = 2, Name = "Chips" });
    
    Expect.Call(repository.All()).Return(recipes);

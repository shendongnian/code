    private ICommand _searchCommand;
    public ICommand SearchCommand
    {
        get
        {
            return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
            {
                var filteredRecipes = App.RecipeDbcontroller.GetRecipeBySearchTerm(text);
                recipes.Clear();
                foreach(var recipe in filteredRecipes )
                     recipes.Add(recipe);
            }));
        }
    }

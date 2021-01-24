    public ICommand SearchCommand => _searchCommand ?? (_searchCommand = new Command<string>((text) =>
    {
        if (text.Length >=1)
        {
            Recipes.Clear();
            Init();
            var suggestions = Recipes.Where(c => c.RecipeName.ToLower().StartsWith(text.ToLower())).ToList();
            Recipes.Clear();
            foreach (var recipe in suggestions)
             Recipes.Add(recipe);
    
        }
        else
        {
            Recipes.Clear();
            Init();
            ListViewVisible = true;
            SuggestionsListViewVisible = false;
        }
    
    }));

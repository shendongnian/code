    using System.Linq;
        //Recipe CRUD
        public IEnumerable<Recipe> GetRecipe()
        {
            lock (locker)
            {
                return this.database.Table<Recipe>();
            }
        }
        public IEnumerable<Recipe> GetRecipeBySearchTerm(string text)
        {
            var recipes = GetRecipe();
            lock (locker)
            {
                return recipes.Where(m => m.RecipeName.ToLower().Contains(text));
            }
        }

        static void Main(string[] args)
        {
            var profile = new DomainProfile();
            Mapper.Initialize(cfg => cfg.AddProfile(profile));
            var recipe = new Recipe
            {
                RecipeParts = new List<RecipePart>
                {
                    new RecipePart()
                    {
                        Ingredient = new Ingredient()
                    }
                }
            };
            var recipeModel = Mapper.Map<Recipe, RecipeModel>(recipe);
            Console.ReadKey();
        }

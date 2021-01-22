    public static class Util
    {
        public static List<Recipe> GetRecipesWhichHaveGivenIngredients(this List<Recipe> recipies, List<Ingredient> ingredients)
        {
            int icount=ingredients.Count;
            var res = recipies.Where(r => r.IngredientList.Where(i => ingredients.Contains(i)).Count() == icount).ToList();
            return res;
        }
    }

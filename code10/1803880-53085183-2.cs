    namespace MyPantry.Models
    {
        public class Recipes
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<string> IngredientName { get; set; }
            public string Instructions { get; set; }
        }
    }

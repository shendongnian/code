     public class RecipeDetails
    {
        public RecipeDetails()
        {
            _ingredients = new ObservableCollection<RecipeIngredient>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        private ObservableCollection<RecipeIngredient> _ingredients;
        private ObservableCollection<RecipeIngredient> Ingredients
        {
            get { return _ingredients; }
        }
    }

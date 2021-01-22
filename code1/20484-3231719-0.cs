      public class NutritionFacts
      {
        public int servingSize { get; private set; }
        public int servings { get; private set; }
        public int calories { get; private set; }
        public int fat { get; private set; }
        public int carbohydrate { get; private set; }
        public int sodium { get; private set; }
    
        public NutritionFacts(int servingSize, int servings, int calories = 0, int fat = 0, int carbohydrate = 0, int sodium = 0)
        {
          this.servingSize = servingSize;
          this.servings = servings;
          this.calories = calories;
          this.fat = fat;
          this.carbohydrate = carbohydrate;
          this.sodium = sodium;
        }
      }

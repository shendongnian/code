    class Cart
    {
        public void AddOrder(string mealCode, int quantity);
        public IReadOnlyCollection<Meal> GetAddedMeals();
    } 

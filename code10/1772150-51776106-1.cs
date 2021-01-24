    public class DinnerSet
    {
        public string Version { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public Dictionary<string, Meal> Meals { get; set; }
    }
    public class Meal
    {
        public string MealID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }

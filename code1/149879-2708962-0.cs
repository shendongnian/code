    private Serving GetServing() {
        if (Servings.Count > 0)
            return Servings[0];
        
        if (!string.IsNullOrEmpty(Description)) {
            FoodDescriptionParser parser = new FoodDescriptionParser();
            return parser.Parse(Description);
        }
        return null;
    }
    private double GetX() {
        Serving serving = GetServing();
        if (serving == null) return 0;
        return serving.X;
    }
    private double GetY() {
        Serving serving = GetServing();
        if (serving == null) return 0;
        return serving.Y;
    }

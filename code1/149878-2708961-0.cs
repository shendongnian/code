    private double Get(Func<SomeType, double> valueProvider)
    {
        if (Servings.Count > 0)
        {
            return valueProvider(Servings[0]);
        }
        if (!string.IsNullOrEmpty(Description))
        {
            FoodDescriptionParser parser = new FoodDescriptionParser();
            return valueProvider(parser.Parse(Description));
        }
        return 0;
    }

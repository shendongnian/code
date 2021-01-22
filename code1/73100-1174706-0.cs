    public Data()
    {
        ingredientDB = new BindingList<Ingredient>();
        ingredientDB.Add(new Ingredient("rice", "a grain", 2));
        ingredientDB.Add(new Ingredient("whole wheat flour", "for baking", 1));
        ingredientDB.Add(new Ingredient("butter", "fatty", 3));
        ingredientDB.Add(new Ingredient("Water", "Wet", 2));
        ingredientDB.Add(new Ingredient("Gin", "Yummy", 2));
    }

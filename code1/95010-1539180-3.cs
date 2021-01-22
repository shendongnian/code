    public static IEnumerable<Animal> GetAllAnimals() {
        using (AnimalDataContext dataContext = new AnimalDataContext()) {
            return new List<Animal>(dataContext.GetAllAnimals());
        }
    }

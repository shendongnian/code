    public static IEnumerable<Animal> GetAllAnimals() {
        using (AnimalDataContext dataContext = new AnimalDataContext()) {
            foreach (var animalName in dataContext.GetAllAnimals()) {
                yield return GetAnimal(animalName);
            }
        }
    }

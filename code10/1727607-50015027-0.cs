    public void UpdatePopulations(IEnumerable<Animal> newAnimals)
    {
        var dictionary = newAnimals.ToDictionary<string, int>(a=>a.Name, a=>a.currentPopulation); // convert to dictionary, so that we have O(1) lookup during the search later. This process itself is O(n)
        foreach(var animal in animalList) // this will be O(n)
        {
            if(dictionary.ContainsKey(animal.Name))
            {
                animal.currentPopulation = dictionary[animal.Name].currentPopulation;
            }
        }
    }

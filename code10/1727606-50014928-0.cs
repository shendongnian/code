    public enum AnimalName
    {
        Lion,
        Cat,
        Dog
    }
    public class Animal
    {
        public AnimalName Name { get; set; }
        public int Population { get; set; }
        public Animal(AnimalName name, int population)
        {
            Name = name;
            Population = population;
        }
    }
    public void UpdatePopulations(int lionPopulation, int catPopulation, int dogPopulation)
        {
            foreach (var animal in animals)
            {
                switch (animal.Name)
                {
                    case AnimalName.Lion:
                        animal.Population = lionPopulation;
                        break;
                    case AnimalName.Cat:
                        animal.Population = catPopulation;
                        break;
                    case AnimalName.Dog:
                        animal.Population = dogPopulation;
                        break;
                }
            }
        }

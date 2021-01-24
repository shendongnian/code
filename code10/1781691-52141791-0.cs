    public static class AnimalFactory
    {
        // Dictionary to map a string to each animal object.
        private static Dictionary<string, GameObject> animalDictionary;
        
        // We'll build our dictionary in the static constructor.
        static AnimalFactory()
        {
            // We can load all the animals from that folder.
            var animals = Resources.LoadAll<GameObject>("Prefabs/Animal");
            animalDictionary =
                new Dictionary<string, GameObject>(animals.Length);
            foreach (GameObject animal in animals)
            {
                animalDictionary.Add(animal.name, animal);
            }
        }
        public static void SpawnAnimal(string animalName, float x, float y)
        {
            if (animalDictionary.ContainsKey(animalName))
            {
                GameObject drop = Object.Instantiate(
                    animalDictionary[animalName],
                    new Vector3(x, y, 0f), Quaternion.identity);
            }
            else
            {
                Debug.LogError("Animal with " + animalName + "could not be " +
                    "found and spawned.");
            }
        }
    }

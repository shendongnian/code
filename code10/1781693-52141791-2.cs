    public static class AnimalFactory
    {
        private static Dictionary<AnimalType, GameObject> animalDictionary;
        static AnimalFactory()
        {
            var animals = Resources.LoadAll<GameObject>("Prefabs/Animal");
            animalDictionary =
                new Dictionary<AnimalType, GameObject>(animals.Length);
            foreach (GameObject animal in animals)
            {
                var typeHolder = animal.GetComponent<AnimalTypeHolder>();
                if (typeHolder != null)
                {
                    animalDictionary.Add(typeHolder.type, animal);
                }
            }
        }
        public static void SpawnAnimal(AnimalType animalType, float x, float y)
        {
            if (animalDictionary.ContainsKey(animalType))
            {
                GameObject drop = Object.Instantiate(
                    animalDictionary[animalType],
                    new Vector3(x, y, 0f), Quaternion.identity);
            }
            else
            {
                Debug.LogError("Animal with " + animalType + "could not be " +
                    "found and spawned.");
            }
        }
    }

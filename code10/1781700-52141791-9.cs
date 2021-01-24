    public static class AnimalFactory
    {
        private static Dictionary<AnimalType, GameObject> animalDictionary;
        private static Dictionary<AnimalType, List<GameObject>> animalPoolActive;
        private static Dictionary<AnimalType, List<GameObject>> animalPoolInActive;
        static AnimalFactory()
        {
            var animals = Resources.LoadAll<GameObject>("Prefabs/Animal");
            animalDictionary =
                new Dictionary<AnimalType, GameObject>(animals.Length);
            animalPoolActive =
                new Dictionary<AnimalType, List<GameObject>>();
            animalPoolInActive =
                new Dictionary<AnimalType, List<GameObject>>(animals.Length);
            foreach (GameObject animal in animals)
            {
                var typeHolder = animal.GetComponent<AnimalTypeHolder>();
                if (typeHolder != null)
                {
                    animalDictionary.Add(typeHolder.type, animal);
                    // Since there are no active animals in the beginning, we'll
                    // create an empty list.
                    animalPoolActive.Add(typeHolder.type,
                        new List<GameObject>());
                    // Make a list to hold our inactive preallocated animals.
                    var prellocAnimals
                        = new List<GameObject>(typeHolder.preallocateCount);
                    for (int i = 0; i < typeHolder.preallocateCount; i++)
                    {
                        var go = Object.Instantiate(animal);
                        go.SetActive(false);
                        prellocAnimals.Add(go);
                    }
                    animalPoolInActive.Add(typeHolder.type, prellocAnimals);
                }
            }
        }
        public static void SpawnAnimal(AnimalType animalType, float x, float y)
        {
            if (animalDictionary.ContainsKey(animalType))
            {
                var inactives = animalPoolInActive[animalType];
                // Check if we have inactive animals of this type we can use.
                if (inactives.Count > 0)
                {
                    // We'll just get the last GameObject in the pool.
                    int last = inactives.Count - 1;
                    GameObject drop = inactives[last];
                    // We have to remove it from the inactive pool now that
                    // we're using it!
                    inactives.RemoveAt(last);
                    // Now we have to add it to the active pool.
                    var actives = animalPoolActive[animalType];
                    actives.Add(drop);
                    drop.SetActive(true);
                    drop.transform.SetPositionAndRotation(new Vector3(x, y, 0f),
                        Quaternion.identity);
                }
                // If we don't have them preallocated, we'll have to instantiate
                // normally.
                else
                {
                    GameObject drop = Object.Instantiate(
                        animalDictionary[animalType],
                        new Vector3(x, y, 0f), Quaternion.identity);
                    animalPoolActive[animalType].Add(drop);
                }
            }
            else
            {
                Debug.LogError("Animal with " + animalType + "could not be " +
                    "found and spawned.");
            }
        }
        public static void UnspawnAnimal(GameObject animal)
        {
            var typeHolder = animal.GetComponent<AnimalTypeHolder>();
            if (typeHolder != null)
            {
                AnimalType type = typeHolder.type;
                var actives = animalPoolActive[type];
                var inactives = animalPoolInActive[type];
                // Check if we're not accidentally using unspawn more than once.
                if (inactives.Contains(animal))
                {
                    Debug.LogWarning("Trying to unspawn an animal that " +
                        "should already be unspawned!");
                    return;
                }
                // First we check if it exists in the active pool.
                if (actives.Contains(animal))
                {
                    // If it exists then we have to remove it now.
                    actives.Remove(animal);
                }
                // We have to add it to the inactive pool for later use.
                inactives.Add(animal);
                // WARNING: In most situations in order to be able to reuse
                // a GameObject like this you need to reset it! For example if
                // your animals have HP then you probably despawned them when
                // they got to zero! You need to reset the HP back to the
                // starting default if you want to reuse the animal!!
            }
            else
            {
                Debug.LogWarning("Attempting to use Unspawn Animal on a " +
                    "GameObject that is either not an animal or doesn't have " +
                    "an AnimalTypeHolder component!");
            }
        }
    }

    public class AnimalFactory
    {
        public static Animal Create(JObject json)
        {
            string animalType = Get animal type string from json;
            Animal a;
            switch (animalType) {
                case "dog":
                    var dog = new Dog();
                    // Fill dog specific stuff.
                    a = dog;
                    break;
                case "cat":
                    var cat = new Cat();
                    // Fill cat specific stuff.
                    a = cat;
                    break;
                default:
                    return null;
            }
            // Fill stuff common to all animals into a.
            return a;
        }
    }

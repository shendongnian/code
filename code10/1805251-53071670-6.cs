    public class AnimalFactory
    {
        public static Animal Create(JObject json)
        {
            string animalType = Get animal type string from json;
            switch (animalType) {
                case "dog":
                    return new Dog(json);
                case "cat":
                    return new Cat(json);
                default:
                    return null;
            }
        }
    }

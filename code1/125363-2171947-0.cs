    public abstract class Animal
    {
    }
    public class Dog : Animal
    {
    }
    public class Cat : Animal
    {
    }
    public static class AnimalSerializer
    {
        public static void Serialize(List<Animal> animals, Stream stream)
        {
            List<Type> animalTypes = new List<Type>();
            foreach (Animal animal in animals)
            {
                Type type = animal.GetType();
                if (!animalTypes.Contains(type))
                {
                    animalTypes.Add(type);
                }
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>), animalTypes.ToArray());
            serializer.Serialize(stream, animals);
        }
    }

     public static class AnimalFactory
    {
        public static Animal Create(string animalName)
        {
            var type = Type.GetType(typeof(Animal).Namespace + "." + animalName, throwOnError: false);
            if (type == null)
            {
                throw new InvalidOperationException(animalName.ToString() + " is not a known Animal type");
            }
            if (!typeof(Animal).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(type.Name + " does not inherit from Animal");
            }
            return (Animal)Activator.CreateInstance(type);
        }
    }

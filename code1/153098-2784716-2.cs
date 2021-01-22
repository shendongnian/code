    public enum AnimalType
    {
        Cat,
        Dog,
        ...
    }
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(AnimalType type)
        {
            switch (type)
            {
                case AnimalType.Cat:
                    return new Cat();
                case AnimalType.Dog:
                    return new Dog();
                default:
                    throw new NotImplementedException();
            }
        }
    }

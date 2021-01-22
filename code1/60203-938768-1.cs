    static class PetFactory
    {
        public static Dog CreatePet(DogDescriptor descriptor)
        {
            return new Dog(descriptor);
        }
        public static Cat CreatePet(CatDescriptor descriptor)
        {
            return new Cat(descriptor);
        }
    }

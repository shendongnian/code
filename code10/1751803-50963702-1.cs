    public abstract class SpecializedDogVet : Vet<Dog>
    {
        public abstract void takeCareOf(Dog dog);
    }
    public abstract class SpecializedCatVet : Vet<Cat>
    {
        public abstract void takeCareOf(Cat cat);
    }

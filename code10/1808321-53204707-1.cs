    public interface IShelter
    {
        Animal Animal { get; set; }
    }
    public interface ISpecificShelter<AnimalType> : IShelter where AnimalType : Animal
    {
        new AnimalType Animal { get; set; }
    }
    public class Shelter<AnimalType> : ISpecificShelter<AnimalType> where AnimalType : Animal
    {
        private Animal _animal;
        public Shelter()
        { }
        Animal IShelter.Animal { get { return _animal; } set { _animal = value; } }
        AnimalType ISpecificShelter<AnimalType>.Animal { get { return (AnimalType)_animal; } set { _animal = value; } }
    }
    // usage:
    ISpecificShelter<Cat> catShelter = new Shelter<Cat>();
    catShelter.Animal = new Cat();
    catShelter.Animal = new Lion(); // compiler error
    Cat cat = catShelter.Animal;
    IShelter shelter = catShelter;
    Animal animal = shelter.Animal;

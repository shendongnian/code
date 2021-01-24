    // this replaces IShelter<Animal>
    public interface IShelter
    {
        Animal Animal { get; set; }
    }
    // this replaces IShelter<SpecificAnimal>
    public interface ISpecificShelter<AnimalType> : IShelter where AnimalType : Animal
    {
        new AnimalType Animal { get; set; }
    }
    // implementation
    public class Shelter<AnimalType> : ISpecificShelter<AnimalType> where AnimalType : Animal
    {
        private Animal _animal;
        public Shelter()
        { }
        // explicit implementation, so the correct implementation is called depending on what interface is used
        Animal IShelter.Animal { get { return _animal; } set { _animal = value; } }
        AnimalType ISpecificShelter<AnimalType>.Animal { get { return (AnimalType)_animal; } set { _animal = value; } }
    }
    // usage:
    // specific animal
    ISpecificShelter<Cat> catShelter = new Shelter<Cat>();
    catShelter.Animal = new Cat();
    catShelter.Animal = new Lion(); // => compiler error!
    Cat cat = catShelter.Animal;
    // cast to general interface
    IShelter shelter = catShelter;
    Animal animal = shelter.Animal;

    public interface IShelter<AnimalType> where AnimalType : Animal
    {
        AnimalType Contents { get; set; }
    }
    public class Shelter<AnimalType> : IShelter<AnimalType> where AnimalType : Animal
    {
        public AnimalType Contents { get; set; }
    }
    IShelter<Cat> catshelter = new Shelter<Cat>();
    catshelter.SetContents(new Cat());
    catshelter.SetContents(new Lion()); // this results in a compiler error

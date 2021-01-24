    public class AnimalContainer : ObservableCollection<Animal>
    {
        public IEnumerable<Dog> Dogs => this.Where(animal => animal is Dog).Cast<Dog>();
        public IEnumerable<Cat> Cats => this.Where(animal => animal is Cat).Cast<Cat>();
    }
    //...
    AnimalContainer container = new AnimalContainer();
    container.Add(new Dog());
    container.Add(new Cat());
    int dogsCount = container.Dogs.Count();
    int catsCount = container.Cats.Count();

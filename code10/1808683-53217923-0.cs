    public abstract class Animal
    {
        // this is the _only_ field that should contain
        // a list of all the animals.
        protected static readonly List<Animal> animals = new List<Animal>();
        // Expose a read-only wrapper as public
        public static IReadOnlyList<Animal> AllAnimals => animals.AsReadOnly();
        protected Animal(string color)
        {
            animals.Add(this);
            this.Color = color;
        }
        public string Color { get; }
        public void RemoveMe()
        {
            int index = animals.IndexOf(this);
            if (index >= 0)
            {
                animals.RemoveAt(index);
            }
        }
    }    
    public class Cat : Animal
    {
        public static IReadOnlyList<Cat> AllCats => animals.OfType<Cat>().ToList().AsReadOnly();
        public Cat(string name, string color) : base(color)
        {
            this.Name = name;
        }
        public string Name { get; }
    }
    public class Fish : Animal
    {
        public static IReadOnlyList<Fish> AllFish => animals.OfType<Fish>().ToList().AsReadOnly();
        public Fish(string color) : base(color)
        {
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var cat1 = new Cat("Whiskers", "Tabby");
            var fish1 = new Fish("Striped");
            var cat2 = new Cat("Snoflake", "White");
            var cat3 = new Cat("Midnight", "Black");
            cat2.RemoveMe();
            // list all remaining cats below
            foreach (var cat in Cat.AllCats)
            {
                Debug.WriteLine($"{cat.Name} is a {cat.Color} cat.");
            }
            // Result in Output:
            //Whiskers is a Tabby cat.
            //Midnight is a Black cat.
        }
    }

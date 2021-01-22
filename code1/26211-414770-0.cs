    public abstract class Animal
    {
        public void DisplayAttributes()
        {
            Console.WriteLine(Header());
            Console.WriteLine("Name: " + Name());
            Console.WriteLine("Legs: " + Legs());
            Console.WriteLine();
        }
        protected virtual int Legs()
        {
            return 4;
        }
        private string Header()
        {
            return "Displaying Animal Attributes";
        }
        protected abstract string Name();
    }
    public class Bird : Animal
    {
        protected override string Name()
        {
            return "Bird";
        }
        protected override int Legs()
        {
            return 2;
        }
    }
    public class Zebra : Animal
    {
        protected override string Name()
        {
            return "Zebra";
        }
    }
    public class Fish : Animal
    {
        protected override string Name()
        {
            return "Fish";
        }
        protected override int Legs()
        {
            return 0;
        }
        private string Header()
        {
            return "Displaying Fish Attributes";
        }
        protected virtual int Gils()
        {
            return 2;
        }
        public new void DisplayAttributes()
        {
            Console.WriteLine(Header());
            Console.WriteLine("Name: " + Name());
            Console.WriteLine("Gils: " + Gils());
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            bird.DisplayAttributes();
            //Displaying Animal Attributes
            //Name: Bird
            //Legs: 2
            Zebra zebra = new Zebra();
            zebra.DisplayAttributes();
            //Displaying Animal Attributes
            //Name: Zebra
            //Legs: 4
            Fish fish = new Fish();
            fish.DisplayAttributes();
            //Displaying Fish Attributes
            //Name: Fish
            //Gils: 2
            List<Animal> animalCollection = new List<Animal>();
            animalCollection.Add(bird);
            animalCollection.Add(zebra);
            animalCollection.Add(fish);
            foreach (Animal animal in animalCollection)
            {
                animal.DisplayAttributes();
                //Displaying Animal Attributes
                //Name: Bird
                //Legs: 2
                //Displaying Animal Attributes
                //Name: Zebra
                //Legs: 4
                //Displaying Animal Attributes
                //Name: Fish
                //Legs: 0
                //*Note the difference here
                //Inheritted member cannot override the
                //base class functionality of a non-virtual member
            }
        }
    }

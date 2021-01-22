        public class Poo
        {
            public virtual string Name { get{ return "Poo"; } }
        }
        public class RadioactivePoo : Poo
        {
            public override string Name { get { return "RadioactivePoo"; } }
            public string DecayPeriod { get { return "Long time"; } }
        }
        public interface IAnimal<out T> where T : Poo
        {
            T Excrement { get; }
        }
        public class Dog : IAnimal<Poo>
        {
            public Poo Excrement { get { return new Poo(); } }
        }
        public class Cat : IAnimal<RadioactivePoo>
        {
            public RadioactivePoo Excrement { get { return new RadioactivePoo(); } }
        }
        static void Main(string[] args)
        {
            var dog = new Dog();
            var cat = new Cat();
            Poo dogPoo = dog.Excrement;
            //RadioactivePoo dogPoo2 = dog.Excrement; // Error
            RadioactivePoo catPoo = cat.Excrement;
            Console.WriteLine("Dog poo name: {0}",dogPoo.Name);
            Console.WriteLine("Cat poo name: {0}, decay period: {1}" ,catPoo.Name, catPoo.DecayPeriod);
            Console.WriteLine("Press any key");
            var key = Console.ReadKey();
        }

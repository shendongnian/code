    class Program
    {
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
        public class Animal<T>:IAnimal<T> where T : Poo 
        {
            public T Excrement { get { return _excrement ?? (_excrement = (T) Activator.CreateInstance(typeof (T), new object[] {})); } } 
            private T _excrement;
        }
        public class Dog : Animal<Poo>{}
        public class Cat : Animal<RadioactivePoo>{}
        static void Main(string[] args)
        {
            var dog = new Dog();
            var cat = new Cat();
            IAnimal<Poo> animal1 = dog;
            IAnimal<Poo> animal2 = cat;
            Poo dogPoo = dog.Excrement;
            //RadioactivePoo dogPoo2 = dog.Excrement; // Error, dog poo is not RadioactivePoo.
            Poo catPoo = cat.Excrement;
            RadioactivePoo catPoo2 = cat.Excrement;
            Poo animal1Poo = animal1.Excrement;
            Poo animal2Poo = animal2.Excrement;
            //RadioactivePoo animal2RadioactivePoo = animal2.Excrement; // Error, IAnimal<Poo> reference do not know better.
            Console.WriteLine("Dog poo name: {0}",dogPoo.Name);
            Console.WriteLine("Cat poo name: {0}, decay period: {1}" ,catPoo.Name, catPoo2.DecayPeriod);
            Console.WriteLine("Press any key");
            var key = Console.ReadKey();
        }
    }

    public interface ISleep { void Sleep(); }
    
    class Nocturnal : ISleep { public void Sleep() => Console.WriteLine("NightOwl"); }
    class Hibernate : ISleep { public void Sleep() => Console.WriteLine("GrizzlyBear"); }
    
    public abstract class Animal
    {
        private readonly ISleep _sleepPattern;
    
        public Animal(ISleep sleepPattern)
        {
            _sleepPattern = sleepPattern ?? throw new NullReferenceException("Can't sleep");
        }
    
        public void Sleep() => _sleepPattern.Sleep();
    }
    
    public class Lion : Animal
    {
        public Lion(ISleep sleepPattern)
            : base(sleepPattern) { }
    }
    
    public class Cat : Lion
    {
        public Cat(ISleep sleepPattern)
            : base(sleepPattern) { }
    }
    
    public class Bear : Animal
    {
        public Bear(ISleep sleepPattern)
            : base(sleepPattern) { }
    }
    
    public class Program
    {
        public static void Main()
        {
            var nocturnal = new Nocturnal();
            var hibernate = new Hibernate();
    
            var animals = new List<Animal>
            {
                new Lion(nocturnal),
                new Cat(nocturnal),
                new Bear(hibernate)
            };
    
            var Garfield = new Cat(hibernate);
            animals.Add(Garfield);
            
            animals.ForEach(a => a.Sleep());
        }
    }

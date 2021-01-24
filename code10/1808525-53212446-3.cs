    public class DoStuff{
            public void TestThings()
            {
                List<Animal> animals = new List<Animal>()
            {
                new Dog(),
                new Cat()
            };
                foreach(Animal animal in animals)
                {
                    Console.WriteLine(animal.GetName("My name is: "+animal.GetType()));
                }
            }
        }

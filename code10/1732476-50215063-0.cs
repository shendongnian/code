    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>();
            for(int i=0; i < 100; i++)
            {
                dogs.Add(new Dog());
            }
            Dog firstDog = dogs[0];
        }
    }
    class Dog
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dog> dogs = new Dictionary<int, Dog>();
            for(int i=0; i < 100; i++)
            {
                dogs.Add(i, new Dog());
            }
            Dog firstDog = dogs[0];
        }
    }
    class Dog
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog[] dogs = new Dog[100];
            for(int i=0; i < 100; i++)
            {
                dogs[i] = new Dog();
            }
            Dog firstDog = dogs[0];
        }
    }
    class Dog
    {
        
    }

    public abstract class Animal
    {
        //some code common to all animals
    }
    public static class AnimalExtension
    {
        public static TAnimal OpenTheEyes<TAnimal>(this TAnimal animal) where TAnimal : Animal
        {
            //Some code to flutter one's eyelashes and then open wide
            return animal; //returning a self reference to allow method chaining
        }
    }
    public class Dog : Animal
    {
        public void Bark() { /* ... */ }
    }
    public class Duck : Animal
    {
        public void Kwak() { /* ... */ }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog Goofy = new Dog();
            Duck Donald = new Duck();
            Goofy.OpenTheEyes().Bark(); //*1
            Donald.OpenTheEyes().Kwak(); //*2
        }
    }

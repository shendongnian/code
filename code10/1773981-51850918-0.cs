    public interface IAnimal
    {
        string Speak();
    }
    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "Meow";
        }
    }
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "Woof";
        }
    }

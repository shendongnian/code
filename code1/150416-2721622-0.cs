    public interface IPet
    {
       void Scratch();
       void Bark();
       void Meow();
    }
    public class Cat : IPet
    {
        public void Scratch()
        {
            Console.WriteLine("Wreck furniture!");
        }
        public void Meow()
        {
           Console.WriteLine("Mew mew mew!");
        }
      
        void IPet.Bark()
        {
            throw NotSupportedException("Cats don't bark!");
        }
    }
    public class Dog : IPet
    {
        public void Scratch()
        {
            Console.WriteLine("Wreck furniture!");
        }
        void IPet.Meow()
        {
           throw new NotSupportedException("Dogs don't meow!");
        }
      
        public void Bark()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }

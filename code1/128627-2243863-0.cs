    public class Dog : IAnimal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    
        public virtual void Move()
        {
            Console.WriteLine("Moved");
        }
    }
    public class FakeDog : Dog
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bark");
        }
    }

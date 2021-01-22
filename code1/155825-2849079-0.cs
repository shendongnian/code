    public abstract class Bird
    {
        protected string Name = string.Empty;
        public Bird(string name)
        {
            this.Name = name;
        }
        public virtual void Fly()
        {
            Console.WriteLine(string.Format("{0} is flying.", this.Name));
        }
        public virtual void Run()
        {
            Console.WriteLine(string.Format("{0} cannot run.", this.Name));
        }
    }
    public class Parrot : Bird
    {
        public Parrot() : base("parrot") { }
    }
    public class Sparrow : Bird
    {
        public Sparrow() : base("sparrow") { }
    }
    public class Penguin : Bird
    {
        public Penguin() : base("penguin") { }
        public override void Fly()
        {
            Console.WriteLine(string.Format("{0} cannot fly. Some birds do not fly.", this.Name));
        }
        public override void Run()
        {
            Console.WriteLine(string.Format("{0} is running. Some birds do run.", this.Name));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Parrot p = new Parrot();
            Sparrow s = new Sparrow();
            Penguin pe = new Penguin();
            List<Bird> birds = new List<Bird>();
            birds.Add(p);
            birds.Add(s);
            birds.Add(pe);
            foreach (Bird bird in birds)
            {
                bird.Fly();
                bird.Run();
            }
            Console.ReadLine();
        }
    }

    public class Human
    {
        public Human()
        {
            Console.WriteLine("I am human");
        }
        public Human(int i)
        {
            Console.WriteLine("I am human " + i);
        }
    }
    public class Man : Human
    {
        public Man()
        {
            Console.WriteLine("I am man");
        }
        public Man(int i)
        {
            // The default base class constructor will be implicitly called here
            Console.WriteLine("I am man " + i);
        }
    }
    public class Woman : Human
    {
        public Woman()
        {
            Console.WriteLine("I am woman");
        }
        public Woman(int i) : base(i)
        {
            // I don't want the default base class constructor, so I force a call to the other constructor
            Console.WriteLine("I am woman " + i);
        }
    }

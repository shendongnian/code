    class Human
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
    class Man : Human
    {
        public Man()
        {
            Console.WriteLine("I am man");
        }
        public Man(int i)
        {
            //the default base class constructor will be implicitly called here
            Console.WriteLine("I am man " + i);
        }
    }
    class Woman : Human
    {
        public Woman()
        {
            Console.WriteLine("I am Woman");
        }
        public Woman(int i) : base(i)
        {
            //I don't want the default base class constructor, so I force a call to the other constructor
            Console.WriteLine("I am Woman " + i);
        }
    }

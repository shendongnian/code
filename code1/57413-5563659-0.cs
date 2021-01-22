    class Character
    {
        public Character Other;
        public string Name;
        private object locker = new object();
        public Character(string name)
        {
            Name = name;
        }
        public void Go()
        {
            lock (locker)
            {
                Thread.Sleep(1000);
                Console.WriteLine("go in {0}", Name);
                Other.Go();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Character a = new Character("A");
            Character b = new Character("B");
            a.Other = b;
            b.Other = a;
            new Thread(a.Go).Start();
            b.Go();
            Console.ReadLine();
        }
    }

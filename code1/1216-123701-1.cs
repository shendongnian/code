        static void Main(string[] args)
        {
            A a = new A { Int32 = int.MaxValue };
            Console.WriteLine(a.Int32);
            Console.WriteLine("{0:X} {1:X} {2:X} {3:X}", a.One, a.Two, a.Three, a.Four);
            
            a.Four = 0;
            a.Three = 0;
            Console.WriteLine(a.Int32);
        }

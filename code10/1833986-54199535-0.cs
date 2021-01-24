    static void Main(string[] args)
        {
            string name;
            float age;
            List<universe> collection = new List<universe>();
            universe main = new universe();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("name");
                name = Console.ReadLine();
                Console.WriteLine("age");
                age = float.Parse(Console.ReadLine());
                main.Galaxy(name, age);
                collection.Add(main);
            }
            foreach (universe b in collection)
            {
                Console.WriteLine("name =" + b.Name + " Age=" + b.Age);
            }
            Console.ReadKey();
        }

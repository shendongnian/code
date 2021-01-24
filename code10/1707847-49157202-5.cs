    class Program
    {
        static void Main(string[] args)
        {
            var container = new MyContainer();
            var application1 = container.Resolve();
            var application2 = container.Resolve();
            Console.WriteLine($"application1.Transient.Name: {application1.Transient.Name}");
            Console.WriteLine($"application2.Transient.Name: {application2.Transient.Name}");
            Console.WriteLine();
            Console.WriteLine($"application1.Singleton.Name: {application1.Singleton.Name}");
            Console.WriteLine($"application2.Singleton.Name: {application2.Singleton.Name}");
            Console.ReadKey();
        }
    }

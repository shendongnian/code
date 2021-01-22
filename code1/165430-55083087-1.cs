    class Test { }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Test>();
            list.Add(null);
            Console.WriteLine(list.OfType<Test>().Count());// 0
            list.Add(new Test());
            Console.WriteLine(list.OfType<Test>().Count());// 1
            Test test = null;
            list.Add(test);
            Console.WriteLine(list.OfType<Test>().Count());// 1
            Console.ReadKey();
        }
    }

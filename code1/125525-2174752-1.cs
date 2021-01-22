    class Foo
    {
        public string foo = "Foo!";
    }
    class Bar
    {
        public int bar = 42;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<dynamic>();
            test.Add(new Foo());
            test.Add(new Bar());
            Console.WriteLine(test[0].foo.Substring(0,3));
            Console.WriteLine(test[1].bar.ToString("000"));
            Console.ReadKey(true);
        }
    }

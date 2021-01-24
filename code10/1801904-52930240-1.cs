    class MyClass
    {
        public int MyNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<MyClass>()
            {
                new MyClass { MyNumber = 99 },
                new MyClass { MyNumber = 123 }
            };
            var objectList = new List<Object>(myList);
            var myConvertedList = objectList.Cast<MyClass>().ToList();
            foreach (int n in myConvertedList.Select(c => c.MyNumber))
                Console.WriteLine(n);
            Console.ReadLine();
        }
    }

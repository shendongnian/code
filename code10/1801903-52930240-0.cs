    class MyClass
    {
        public int MyNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> myList = new List<MyClass>()
            {
                new MyClass {MyNumber = 99},
                new MyClass {MyNumber = 123}
            };
            List<Object> objectList = new List<Object>(myList);
            var myConvertedList = objectList.Cast<MyClass>();
            foreach (int n in myConvertedList.Select(c => c.MyNumber))
                Console.WriteLine(n);
            Console.ReadLine();
        }
    }

    class Program
    {
        public static Person Person { get; set; }
        static void Main(string[] args)
        {
            Person = new Person
            {
                Age = 10,
                Name = "Andrew"
            };
            TestOutput();
        }
        /// <summary>
        /// Method to show result
        /// </summary>
        static void TestOutput()
        {
            Console.WriteLine(Person.Name);
        }
    }

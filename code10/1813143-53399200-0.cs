    class Program
    {
        static void Main(string[] args)
        {
            // This will cause an exception 
            var someString = "SomeValue"; 
            var x = double.Parse(someString);  // Comment this line out to run this example
            // This will work 
            double y;
            if (double.TryParse(someString, out y))
            {
                Console.WriteLine(someString + " is a valid decimal");
            }
            else
            {
                Console.WriteLine(someString + " is not a valid decimal");
            }
            someString = "14.7";
            if (double.TryParse(someString, out y))
            {
                Console.WriteLine(someString + " is a valid decimal");
            }
            else
            {
                Console.WriteLine(someString + " is not a valid decimal");
            }
        }
    }

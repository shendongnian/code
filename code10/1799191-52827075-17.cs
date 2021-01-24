    class Program
    {
        static void Main(string[] args)
        {
            var myEnumerable = new MyEnumerable();
    
            foreach (var item in myEnumerable)
                Console.WriteLine(item);
    
            Console.ReadKey();
        }
    
        // OUTPUT
        // First
        // Second
        // Third
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> enumerable = new MyEnumerable<Person>();
            IEnumerator<Person> enumerator = enumerable.GetEnumerator();
    
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current.Name);
    
            Console.ReadKey();
        }
        // OUTPUT
        // Test 0
        // Test 1
        // Test 2
    }

    class Program
     {
        static void Main(string[] args)
        {
    
            string input = @"oaaawaala";
            string word = "Owl";
    
            var found = word.ToCharArray().Select(c => char.ToUpper(c)).Distinct().All(c => input.ToUpper().Contains(c));
    
            Console.WriteLine("Found: {0}", found);
        }
    }

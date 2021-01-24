    public class RecursiveFactory : IRecursiveFactory
    {
        private readonly Lazy<IRecursiveFactory> _recursiveFactory;
        public RecursiveFactory(Lazy<IRecursiveFactory> recursiveFactory)
        {
            _recursiveFactory = recursiveFactory;
        }
        public int Add(int number, int max = 10)
        {
            while (number < max)
            {
                var newNumber = number + 1;
                Console.WriteLine(newNumber);
                number = _recursiveFactory.Value.Add(newNumber);
            }
            return number;
        }
    }

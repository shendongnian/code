    NaturalNumbersSequence : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int i = 0;
            while (i <= int.MaxValue)
                yield return i;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            int i = 0;
            while (i <= int.MaxValue)
                yield return i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in new NaturalNumbersSequence().TakeWhile(i => i<=1000) )
                Console.WriteLine(i);
        }
    }

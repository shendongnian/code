    public static class NumbersSequence
    {
        public static IEnumerable<int> Naturals
        {
            get 
            {
                for (int i = 1; i <= 1000; i++)
                    yield return i;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in NumbersSequence.Naturals)
                Console.WriteLine(i);
        }
    }

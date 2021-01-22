    public static class NumbersSequence
    {
        public static IEnumerable<int> Naturals
        {
            get 
            {
                int i = 0;
                while(true)
                    yield return i++;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in NumbersSequence.Naturals.Take(1000))
                Console.WriteLine(i);
        }
    }

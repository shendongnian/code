    public class NaturalNumbersSequence : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i=0 i <= int.MaxValue;i++)
                yield return i;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i=0 i <= int.MaxValue;i++)
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

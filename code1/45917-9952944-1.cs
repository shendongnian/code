    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<int> circularNumbers = numbers.AsCircular();
            
            IEnumerable<int> firstFourNumbers = circularNumbers.Take(4); // 1 2 3 4
            IEnumerable<int> nextSevenNumbersfromfourth = circularNumbers
                .Skip(4).Take(7); // 4 5 6 7 1 2 3 
        }
    }
    public static class CircularEnumerable
    {
        public static IEnumerable<T> AsCircular<T>(this IEnumerable<T> source)
        {
            if (source == null)
                yield break; // be a gentleman
            IEnumerator<T> enumerator = source.GetEnumerator();
         
            iterateAllAndBackToStart:
            while (enumerator.MoveNext()) 
                yield return enumerator.Current;
            enumerator.Reset();
            if(!enumerator.MoveNext())
                yield break;
    goto iterateAllAndBackToStart;
        }
    }

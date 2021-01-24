    public class Program
    {
        static void Main(string[] args)
        {
            //
            // First a fairly simple visual test
            //
            var someCollection = new string[] { "four", "score", "and", "twenty", "years", "ago" };
            var someOrderablePartitioner = new SingleElementOrderablePartitioner<string>(someCollection);
            Parallel.ForEach(someOrderablePartitioner, (item, state, index) =>
            {
                Console.WriteLine("ForEach: item = {0}, index = {1}, thread id = {2}", item, index, Thread.CurrentThread.ManagedThreadId);
            });
    
            //
            // Now a more rigorous test of dynamic partitioning (used by Parallel.ForEach)
            //
            List<int> src = Enumerable.Range(0, 100000).ToList();
            SingleElementOrderablePartitioner<int> myOP = new SingleElementOrderablePartitioner<int>(src);
    
            int counter = 0;
            bool mismatch = false;
            Parallel.ForEach(myOP, (item, state, index) =>
            {
                if (item != index) mismatch = true;
                Interlocked.Increment(ref counter);
            });
    
            if (mismatch) Console.WriteLine("OrderablePartitioner Test: index mismatch detected");
            Console.WriteLine("OrderablePartitioner test: counter = {0}, should be 100000", counter);
        }
    }

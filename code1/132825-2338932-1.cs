    public class ThreadSafeList<T>
    {
        // snip fields
        public void Add(T item)
        {
            lock (sync)
            {
                TestUtil.WaitStandardThreadDelay();
                innerList.Add(item);
            }
        }
        // snip other methods/properties
    }
    static class TestUtil
    {
        [Conditional("TEST")]
        public static void WaitStandardThreadDelay()
        {
            Thread.Sleep(1000);
        }
    }

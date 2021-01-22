    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var limit = 9400;
                while (true)
                {
                    var thread = new Thread(() => IncreaseMemory(limit));
                    thread.Start();
                }
            }
            catch (Exception)
            {
                // swallow exception
            }
            
        }
        private static void IncreaseMemory(long limity)
        {
            var limit = limity;
            var list = new List<byte[]>();
            try
            {
                while(true)
                {
                    list.Add(new byte[limit]); // Change the size here.
                    Thread.Sleep(1000); // Change the wait time here.
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }
        }
    }

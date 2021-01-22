    class Program
    {
        static void Main(string[] args)
        {
            var uids = Enumerable.Range(1, 21).ToArray();
            var chunks = from index in Enumerable.Range(0, uids.Length)
                         group uids[index] by index / 10;
            foreach (var currentChunks in chunks)
            {
                Console.WriteLine("KEY: {0}", currentChunks.Key);
                // TODO: string[] data = GetDataForUids(currentChunks.ToArray());
                foreach (var uid in currentChunks)
                {
                    Console.WriteLine(uid);
                }
            }
        }
    }

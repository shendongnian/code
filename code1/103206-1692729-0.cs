    class Program
    {
        static void Main(string[] args)
        {
            var uids = Enumerable.Range(1, 21).ToArray();
            var chunks = from index in Enumerable.Range(0, uids.Length)
                         group uids[index] by index / 10;
            foreach (var item in chunks)
            {
                Console.WriteLine("KEY: {0}", item.Key);
                // TODO: GetDataForUids(item)
                foreach (var x in item)
                {
                    Console.WriteLine(x);    
                }
            }
        }
    }

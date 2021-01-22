    static void DoStuff(int[] uidArray)
    {
        const int length = 10;
        IEnumerable<int> parts = uidArray;
        while(parts.Any())
        {
            int[] currentChunks = parts.Take(length).ToArray();
            string[] data = GetDataForUids(currentChunks);
            parts = parts.Skip(length);
            foreach (string item in data)
            {
                Console.WriteLine(item);
            }
        }
    }

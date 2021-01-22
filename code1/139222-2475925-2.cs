     static void Main()
        {
            List<int> identifiers = new List<int>() { 1, 2, 4, 7, 9 };
    
            Stopwatch sw = new Stopwatch();
    
            sw.Start();
            List<int> miss = GetMiss(identifiers,150000);
            sw.Stop();
            Console.WriteLine("{0}",sw.ElapsedMilliseconds);
    
        }
    private static List<int> GetMiss(List<int> identifiers,int length)
    {
        List<int> miss = new List<int>();
        int j = 0;
        for (int i = 0; i < length; i++)
        {
            if (i < identifiers[j])
                miss.Add(i);
            else if (i == identifiers[j])
                j++;
            if (j == identifiers.Count)
            {
                miss.AddRange(Enumerable.Range(i + 1, length - i));
                break;
            }
        }
        
        return miss;
    }

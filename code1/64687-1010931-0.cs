    class Program
    {
        static void Main(string[] args)
        {
            const int where = 5;
            var aList = new List<int>();
            for (var i=0; i < 100; i++)
                aList.Add(i);
            var reversed = aList.Take(where).Concat(Enumerable.Reverse(aList)
                .Take(aList.Count - where));
            Console.WriteLine(String.Join(",",
                reversed.Select(i => i.ToString()).ToArray()));
            Console.ReadLine();
        }
    }

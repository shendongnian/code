    class Program
    {
        static void Main()
        {
            List<Tuple<string, int>> test = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("one",   1),
                new Tuple<string, int>("two",   2),
                new Tuple<string, int>("three", 3)
            };
            var extract = new TupleExtraction<string, int>(test);
            for (int i = 0; i < extract.Count; ++i)
                Console.WriteLine(extract[i]);
            foreach (var item in extract)
                Console.WriteLine(item);
        }
    }

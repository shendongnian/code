    public static class Tools
    {
        public static void Foreach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (var item in input)
                action(item);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // the line below is standing in for your text file.  
            // this could be replaced by anything that returns IEnumerable<string>
            var data = new [] { "A 1 3", "B 2 5", "A 1 6", "G 2 7" };
            var format = "Alt: {1} BpM: {2} Type: {0}";
            var lines = from line in data
                        where line.StartsWith("A")
                        let parts = line.Split(' ')
                        let formatted = string.Format(format, parts)
                        select formatted;
            var page = lines.Skip(1).Take(2);
            page.Foreach(Console.WriteLine);
            // at this point the following will be written to the console
            //
            // Alt: 1 BpM: 6 Type: A
            //
        }
    }
